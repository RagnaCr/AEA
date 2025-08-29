using Core.Application.Common.Interfaces;
using Core.Application.Features.Auth.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Features.Portfolios.Commands.Queries;
public class GetPortfolioByIdQueryHandler : IRequestHandler<GetPortfolioByIdQuery, PortfolioDto?>
{
    private readonly IApplicationDbContext _context;

    public GetPortfolioByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PortfolioDto?> Handle(GetPortfolioByIdQuery request, CancellationToken cancellationToken)
    {
        var portfolio = await _context.Portfolios
            // КРИТИЧЕСКИ ВАЖНО: ищем по ID и проверяем, что UserId совпадает
            .Where(p => p.Id == request.PortfolioId && p.UserId == request.UserId)
            .Select(p => new PortfolioDto
            {
                Id = p.Id,
                Name = p.Name
            })
            .FirstOrDefaultAsync(cancellationToken);

        // Если портфель с таким ID не существует ИЛИ он не принадлежит пользователю,
        // FirstOrDefaultAsync вернет null.
        return portfolio;
    }
}