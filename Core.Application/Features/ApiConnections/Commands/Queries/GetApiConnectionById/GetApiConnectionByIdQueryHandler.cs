using Core.Application.Common.Interfaces;
using Core.Application.Features.ApiConnections.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Features.ApiConnections.Commands.Queries.GetApiConnectionById;

public class GetApiConnectionByIdQueryHandler : IRequestHandler<GetApiConnectionByIdQuery, ApiConnectionDto?>
{
    private readonly IApplicationDbContext _context;

    public GetApiConnectionByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiConnectionDto?> Handle(GetApiConnectionByIdQuery request, CancellationToken cancellationToken)
    {
        var connection = await _context.ApiConnections
            // Ищем по ID и проверяем, что UserId совпадает
            .Where(c => c.Id == request.ConnectionId && c.UserId == request.UserId)
            .Select(c => new ApiConnectionDto
            {
                Id = c.Id,
                ConnectionName = c.ConnectionName,
                ExchangeName = c.ExchangeName,
                Status = c.Status,
                LastSuccessfulSync = c.LastSuccessfulSync,
                LastErrorMessage = c.LastErrorMessage
            })
            .FirstOrDefaultAsync(cancellationToken);

        // Если не найдено или не принадлежит пользователю, вернется null
        return connection;
    }
}