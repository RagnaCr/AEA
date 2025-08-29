using Core.Application.Common.Interfaces;
using Core.Application.Features.Portfolios.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Features.Portfolios.Commands.Queries.GetPortfolioBalances;

public class GetPortfolioBalancesQueryHandler : IRequestHandler<GetPortfolioBalancesQuery, List<BalanceDto>>
{
    private readonly IApplicationDbContext _context;

    public GetPortfolioBalancesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<BalanceDto>> Handle(GetPortfolioBalancesQuery request, CancellationToken cancellationToken)
    {
        // 1. Проверка прав на портфель
        var portfolioExists = await _context.Portfolios
            .AnyAsync(p => p.Id == request.PortfolioId && p.UserId == request.UserId, cancellationToken);

        if (!portfolioExists)
        {
            return new List<BalanceDto>();
        }

        // 2. Расчет балансов
        var balances = await _context.TransactionLegs
            .Where(l => l.Operation.PortfolioId == request.PortfolioId) // Фильтруем "ноги" по портфелю
            .GroupBy(l => new { l.AssetId, l.Asset.Ticker, l.Asset.Name }) // Группируем по ассету
            .Select(g => new BalanceDto
            {
                AssetId = g.Key.AssetId,
                AssetTicker = g.Key.Ticker,
                AssetName = g.Key.Name,
                // Суммируем (Количество * Направление) для каждой "ноги" в группе
                TotalQuantity = g.Sum(l => l.Quantity * l.Direction)
            })
            // Отфильтровываем активы с нулевым балансом, они нам не интересны
            .Where(b => b.TotalQuantity != 0)
            .OrderBy(b => b.AssetTicker)
            .ToListAsync(cancellationToken);

        return balances;
    }
}