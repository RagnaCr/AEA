using Core.Application.Common.Interfaces;
using Core.Application.Features.Operations.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Features.Operations.Queries.GetOperationsByPortfolio;

public class GetOperationsByPortfolioQueryHandler : IRequestHandler<GetOperationsByPortfolioQuery, List<OperationDto>>
{
    private readonly IApplicationDbContext _context;

    public GetOperationsByPortfolioQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<OperationDto>> Handle(GetOperationsByPortfolioQuery request, CancellationToken cancellationToken)
    {
        // 1. Проверяем, что портфель вообще существует и принадлежит пользователю
        var portfolioExists = await _context.Portfolios
            .AnyAsync(p => p.Id == request.PortfolioId && p.UserId == request.UserId, cancellationToken);

        if (!portfolioExists)
        {
            // Можно бросить исключение или вернуть пустой список. 
            // Возврат пустого списка безопаснее, т.к. не раскрывает, существует ли портфель.
            return new List<OperationDto>();
        }

        // 2. Получаем операции с их "ногами" и связанными ассетами
        var operations = await _context.Operations
            .Where(o => o.PortfolioId == request.PortfolioId)
            .Include(o => o.Legs)
                .ThenInclude(l => l.Asset) // Включаем информацию об основном ассете
            .Include(o => o.Legs)
                .ThenInclude(l => l.PriceCurrency) // Включаем информацию о валюте цены
            .OrderByDescending(o => o.Timestamp) // Сначала самые новые
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(o => new OperationDto
            {
                Id = o.Id,
                Type = o.Type,
                Source = o.Source,
                Timestamp = o.Timestamp,
                Notes = o.Notes,
                Status = o.Status,
                Legs = o.Legs.Select(l => new TransactionLegDto
                {
                    AssetTicker = l.Asset.Ticker,
                    AssetName = l.Asset.Name,
                    Type = l.Type,
                    Quantity = l.Quantity,
                    Direction = l.Direction,
                    PricePerUnit = l.PricePerUnit,
                    PriceCurrencyTicker = l.PriceCurrency != null ? l.PriceCurrency.Ticker : null
                }).ToList()
            })
            .ToListAsync(cancellationToken);

        return operations;
    }
}