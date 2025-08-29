using Core.Application.Common.Interfaces;
using Core.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Core.Application.Features.Portfolios.Commands.CreateDailySnapshot;

public class CreateDailySnapshotCommandHandler : IRequestHandler<CreateDailySnapshotCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMarketDataService _marketDataService;

    public CreateDailySnapshotCommandHandler(IApplicationDbContext context, IMarketDataService marketDataService)
    {
        _context = context;
        _marketDataService = marketDataService;
    }

    public async Task<Unit> Handle(CreateDailySnapshotCommand request, CancellationToken cancellationToken)
    {
        // 1. Получаем портфель и его API подключения
        var portfolio = await _context.Portfolios
            .Include(p => p.ApiConnections)
                .ThenInclude(pac => pac.ApiConnection)
            .FirstOrDefaultAsync(p => p.Id == request.PortfolioId, cancellationToken);

        if (portfolio == null) return Unit.Value; // Портфель мог быть удален, просто выходим

        // 2. Рассчитываем балансы на КОНЕЦ указанного дня
        var endOfDay = request.Date.Date.AddDays(1).AddTicks(-1); // 23:59:59.999...
        var balances = await _context.TransactionLegs
            .Where(l => l.Operation.PortfolioId == request.PortfolioId && l.Operation.Timestamp <= endOfDay) // <-- ВАЖНОЕ ОТЛИЧИЕ
            .GroupBy(l => new { l.Asset.Ticker })
            .Select(g => new { Ticker = g.Key.Ticker, TotalQuantity = g.Sum(l => l.Quantity * l.Direction) })
            .Where(b => b.TotalQuantity != 0)
            .ToListAsync(cancellationToken);

        // 3. Получаем цены для этих активов
        var tickers = balances.Select(b => b.Ticker);
        var connections = portfolio.ApiConnections.Select(pac => pac.ApiConnection);
        var prices = await _marketDataService.GetCurrentPricesAsync(connections, tickers); // Получаем ТЕКУЩИЕ цены
        var pricesDict = prices.ToDictionary(p => p.Ticker);

        // 4. Считаем общую стоимость
        decimal totalMarketValue = 0;
        foreach (var balance in balances)
        {
            if (pricesDict.TryGetValue(balance.Ticker, out var marketPrice))
            {
                // TODO: Учесть конвертацию валют
                totalMarketValue += balance.TotalQuantity * marketPrice.Price;
            }
        }

        // 5. Находим или создаем снэпшот на эту дату
        var snapshot = await _context.PortfolioDailySnapshots
            .FirstOrDefaultAsync(s => s.PortfolioId == request.PortfolioId && s.Date == request.Date.Date, cancellationToken);

        if (snapshot == null)
        {
            snapshot = new PortfolioDailySnapshot
            {
                PortfolioId = request.PortfolioId,
                Date = request.Date.Date
            };
            _context.PortfolioDailySnapshots.Add(snapshot);
        }

        // 6. Обновляем его стоимость и сохраняем
        snapshot.MarketValue = totalMarketValue;
        // TODO: Расчет CostBasis - это отдельная, более сложная задача. Пока оставим 0.
        snapshot.CostBasis = 0;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}