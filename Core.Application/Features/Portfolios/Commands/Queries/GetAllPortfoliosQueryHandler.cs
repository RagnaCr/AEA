using Core.Application.Common.Interfaces;
using Core.Application.Features.Auth.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Features.Portfolios.Commands.Queries;
public class GetAllPortfoliosQueryHandler : IRequestHandler<GetAllPortfoliosQuery, List<PortfolioDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllPortfoliosQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<PortfolioDto>> Handle(GetAllPortfoliosQuery request, CancellationToken cancellationToken)
    {
        var portfolios = await _context.Portfolios
            .Where(p => p.UserId == request.UserId) // Выбираем портфели только этого пользователя
            .OrderBy(p => p.Name) // Сортируем для порядка
            .Select(p => new PortfolioDto // Проецируем в DTO
            {
                Id = p.Id,
                Name = p.Name
            })
            .ToListAsync(cancellationToken);

        return portfolios;
    }
}