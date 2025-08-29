using Core.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Features.ApiConnections.Commands.Delete;
public class DeleteApiConnectionCommandHandler : IRequestHandler<DeleteApiConnectionCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteApiConnectionCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<bool> Handle(DeleteApiConnectionCommand request, CancellationToken cancellationToken)
    {
        var connection = await _context.ApiConnections
            .FirstOrDefaultAsync(c => c.Id == request.ConnectionId && c.UserId == request.UserId, cancellationToken);

        if (connection == null)
        {
            return false;
        }

        _context.ApiConnections.Remove(connection);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}