using Core.Application.Common.Interfaces;
using Core.Domain.Entity;
using MediatR;

namespace Core.Application.Features.ApiConnections.Commands.Create
{
    public class CreateApiConnectionCommandHandler : IRequestHandler<CreateApiConnectionCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDataProtectionService _dataProtectionService;

        public CreateApiConnectionCommandHandler(IApplicationDbContext context, IDataProtectionService dataProtectionService)
        {
            _context = context;
            _dataProtectionService = dataProtectionService;
        }

        public async Task<Guid> Handle(CreateApiConnectionCommand request, CancellationToken cancellationToken)
        {
            // Шифруем ключи перед созданием сущности
            var encryptedKey1 = _dataProtectionService.Encrypt(request.ApiKey);
            var encryptedKey2 = !string.IsNullOrEmpty(request.ApiSecret)
                ? _dataProtectionService.Encrypt(request.ApiSecret)
                : null;

            var connection = new ApiConnection(
                request.UserId,
                request.ConnectionName,
                request.ExchangeName,
                encryptedKey1,
                encryptedKey2
            );

            _context.ApiConnections.Add(connection);
            await _context.SaveChangesAsync(cancellationToken);

            return connection.Id;
        }
    }
}
