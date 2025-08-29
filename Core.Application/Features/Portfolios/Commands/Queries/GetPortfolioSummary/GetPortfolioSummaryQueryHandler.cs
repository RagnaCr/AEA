using Core.Application.Common.Interfaces;
using Core.Application.Features.Portfolios.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.Portfolios.Commands.Queries.GetPortfolioSummary;
public class GetPortfolioSummaryQueryHandler : IRequestHandler<GetPortfolioSummaryQuery, PortfolioSummaryDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMarketDataService _marketDataService;

    public GetPortfolioSummaryQueryHandler(IApplicationDbContext context, IMarketDataService marketDataService)
    {
        _context = context;
        _marketDataService = marketDataService;
    }

    public async Task<PortfolioSummaryDto> Handle(GetPortfolioSummaryQuery request, CancellationToken cancellationToken)
    {
        // 1. Получаем портфель и проверяем права
        var portfolio = await _context.Portfolios
        .Include(p => p.ApiConnections)
        .ThenInclude(pac => pac.ApiConnection)
        .FirstOrDefaultAsync(p => p.Id == request.PortfolioId && p.UserId == request.UserId, cancellationToken);

        if (portfolio == null)
        {
            throw new KeyNotFoundException("Portfolio not found.");
        }

        // 2. Получаем балансы (используем уже существующую логику)
        // В идеале - вынести логику расчета балансов в отдельный сервис, чтобы не дублировать код,
        // но для начала можно скопировать логику из GetPortfolioBalancesQueryHandler.
        var balances = await _context.TransactionLegs
            .Where(l => l.Operation.PortfolioId == request.PortfolioId)
            .GroupBy(l => new { l.AssetId, l.Asset.Ticker, l.Asset.Name })
            .Select(g => new { g.Key.AssetId, g.Key.Ticker, TotalQuantity = g.Sum(l => l.Quantity * l.Direction) })
            .Where(b => b.TotalQuantity != 0)
            .ToListAsync(cancellationToken);

        // 3. Получаем цены для наших активов
        var tickers = balances.Select(b => b.Ticker);
        var connections = portfolio.ApiConnections.Select(pac => pac.ApiConnection);
        var prices = await _marketDataService.GetCurrentPricesAsync(connections, tickers);
        var pricesDict = prices.ToDictionary(p => p.Ticker);

        // 4. Формируем DTO
        var summary = new PortfolioSummaryDto
        {
            PortfolioId = portfolio.Id,
            PortfolioName = portfolio.Name
        };

        foreach (var balance in balances)
        {
            pricesDict.TryGetValue(balance.Ticker, out var marketPrice);
            var totalValue = marketPrice != null ? balance.TotalQuantity * marketPrice.Price : (decimal?)null;

            summary.Assets.Add(new PortfolioAssetSummaryDto
            {
                AssetId = balance.AssetId,
                Ticker = balance.Ticker,
                Quantity = balance.TotalQuantity,
                CurrentPrice = marketPrice?.Price,
                PriceCurrency = marketPrice?.Currency,
                TotalValue = totalValue
            });

            if (totalValue.HasValue)
            {
                // TODO: Добавить конвертацию, если валюты разные
                summary.TotalValue += totalValue.Value;
            }
        }

        return summary;
    }
}