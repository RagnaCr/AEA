using Core.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Features.ApiConnections.Commands.Update;
public class UpdateApiConnectionCommandHandler : IRequestHandler<UpdateApiConnectionCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IDataProtectionService _dataProtectionService;

    public UpdateApiConnectionCommandHandler(IApplicationDbContext context, IDataProtectionService dataProtectionService)
    {
        _context = context;
        _dataProtectionService = dataProtectionService;
    }

    public async Task<bool> Handle(UpdateApiConnectionCommand request, CancellationToken cancellationToken)
    {
        var connection = await _context.ApiConnections
            .FirstOrDefaultAsync(c => c.Id == request.ConnectionId && c.UserId == request.UserId, cancellationToken);

        if (connection == null)
        {
            return false;
        }

        // Шифруем новые ключи
        var encryptedKey1 = _dataProtectionService.Encrypt(request.ApiKey);
        var encryptedKey2 = !string.IsNullOrEmpty(request.ApiSecret)
            ? _dataProtectionService.Encrypt(request.ApiSecret)
            : null;

        // Обновляем сущность. В будущем можно вынести в метод доменной сущности.
        connection.UpdateDetails(request.ConnectionName, encryptedKey1, encryptedKey2);

        // Сбрасываем статус при обновлении ключей, т.к. нужна новая проверка
        connection.ResetStatus();

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}