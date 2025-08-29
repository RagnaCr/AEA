using Core.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Core.Application.Features.ApiConnections.Commands.LinkApiConnection;

public class LinkApiConnectionCommandHandler : IRequestHandler<LinkApiConnectionCommand>
{
    private readonly IApplicationDbContext _context;

    public LinkApiConnectionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(LinkApiConnectionCommand request, CancellationToken cancellationToken)
    {
        // 1. Находим портфель и УБЕЖДАЕМСЯ, что он принадлежит пользователю
        var portfolio = await _context.Portfolios
            .Include(p => p.ApiConnections) // Включаем, чтобы проверить существующие связи
            .FirstOrDefaultAsync(p => p.Id == request.PortfolioId && p.UserId == request.UserId, cancellationToken);

        if (portfolio == null)
        {
            throw new KeyNotFoundException("Portfolio not found or access is denied.");
        }

        // 2. Находим API-подключение и УБЕЖДАЕМСЯ, что оно тоже принадлежит пользователю
        var connectionExists = await _context.ApiConnections
            .AnyAsync(c => c.Id == request.ConnectionId && c.UserId == request.UserId, cancellationToken);

        if (!connectionExists)
        {
            throw new KeyNotFoundException("API connection not found or access is denied.");
        }

        // 3. Используем доменный метод для создания связи.
        // Он инкапсулирует логику проверки, чтобы не создавать дубликаты.
        var connection = await _context.ApiConnections.FindAsync(request.ConnectionId); // Получаем сам объект
        portfolio.LinkApiConnection(connection);

        // 4. Сохраняем изменения
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
