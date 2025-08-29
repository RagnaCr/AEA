using Core.Application.Common.Interfaces;
using Core.Application.Features.ApiConnections.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Features.ApiConnections.Commands.Queries;

public class GetAllApiConnectionsQueryHandler : IRequestHandler<GetAllApiConnectionsQuery, List<ApiConnectionDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllApiConnectionsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ApiConnectionDto>> Handle(GetAllApiConnectionsQuery request, CancellationToken cancellationToken)
    {
        var connections = await _context.ApiConnections
            .Where(c => c.UserId == request.UserId) // Выбираем подключения только текущего пользователя
            .OrderBy(c => c.ConnectionName)
            .Select(c => new ApiConnectionDto
            {
                Id = c.Id,
                ConnectionName = c.ConnectionName,
                ExchangeName = c.ExchangeName,
                Status = c.Status,
                LastSuccessfulSync = c.LastSuccessfulSync,
                LastErrorMessage = c.LastErrorMessage
                // Мы НЕ возвращаем зашифрованные ключи клиенту
            })
            .ToListAsync(cancellationToken);

        return connections;
    }
}