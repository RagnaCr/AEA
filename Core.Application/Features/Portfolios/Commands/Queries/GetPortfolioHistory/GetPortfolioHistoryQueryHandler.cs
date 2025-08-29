using Core.Application.Common.Interfaces;
using Core.Application.Features.Portfolios.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.Portfolios.Commands.Queries.GetPortfolioHistory;

public class GetPortfolioHistoryQueryHandler : IRequestHandler<GetPortfolioHistoryQuery, List<PortfolioSnapshotDto>>
{
    private readonly IApplicationDbContext _context;

    public GetPortfolioHistoryQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<PortfolioSnapshotDto>> Handle(GetPortfolioHistoryQuery request, CancellationToken cancellationToken)
    {
        // 1. Проверяем права доступа к портфелю. Это также гарантирует, что портфель существует.
        var hasAccess = await _context.Portfolios
            .AnyAsync(p => p.Id == request.PortfolioId && p.UserId == request.UserId, cancellationToken);

        if (!hasAccess)
        {
            // Возвращаем пустой список, если нет доступа или портфель не существует.
            return new List<PortfolioSnapshotDto>();
        }

        // 2. Выбираем снэпшоты для данного портфеля
        var history = await _context.PortfolioDailySnapshots
            .Where(s => s.PortfolioId == request.PortfolioId)
            .OrderBy(s => s.Date) // Сортируем по дате для правильного отображения на графике
            .Select(s => new PortfolioSnapshotDto
            {
                Date = s.Date,
                MarketValue = s.MarketValue
            })
            .ToListAsync(cancellationToken);

        return history;
    }
}