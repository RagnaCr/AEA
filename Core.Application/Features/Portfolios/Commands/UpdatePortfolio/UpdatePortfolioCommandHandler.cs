using Core.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Features.Portfolios.Commands.UpdatePortfolio;
public class UpdatePortfolioCommandHandler : IRequestHandler<UpdatePortfolioCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdatePortfolioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdatePortfolioCommand request, CancellationToken cancellationToken)
    {
        // 1. Найти портфель, обязательно проверив и ID портфеля, и ID пользователя.
        var portfolio = await _context.Portfolios
            .FirstOrDefaultAsync(p => p.Id == request.PortfolioId && p.UserId == request.UserId, cancellationToken);

        // 2. Если не найден (или не принадлежит пользователю), вернуть false.
        if (portfolio == null)
        {
            return false;
        }

        portfolio.UpdateName(request.NewName);

        // 4. Сохранить изменения.
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}