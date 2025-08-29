using Core.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Features.Portfolios.Commands.DeletePortfolio;

public class DeletePortfolioCommandHandler : IRequestHandler<DeletePortfolioCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeletePortfolioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeletePortfolioCommand request, CancellationToken cancellationToken)
    {
        var portfolio = await _context.Portfolios
            .FirstOrDefaultAsync(p => p.Id == request.PortfolioId && p.UserId == request.UserId, cancellationToken);

        if (portfolio == null)
        {
            return false;
        }

        _context.Portfolios.Remove(portfolio);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}