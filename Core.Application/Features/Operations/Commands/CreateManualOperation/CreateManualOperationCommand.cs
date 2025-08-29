using Core.Application.Features.Operations.Dtos;
using MediatR;

namespace Core.Application.Features.Operations.Commands.CreateManualOperation;
public class CreateManualOperationCommand : IRequest<Guid>
{
    public Guid PortfolioId { get; set; }
    public Guid UserId { get; set; } // Для проверки прав и поиска кастомных ассетов
    public CreateManualOperationRequest OperationRequest { get; set; }
}
