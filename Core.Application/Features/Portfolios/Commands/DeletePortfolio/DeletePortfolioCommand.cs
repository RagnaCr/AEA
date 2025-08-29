using MediatR;

namespace Core.Application.Features.Portfolios.Commands.DeletePortfolio;

public class DeletePortfolioCommand : IRequest<bool>
{
    public Guid PortfolioId { get; set; }
    public Guid UserId { get; set; } // Для проверки прав
}
