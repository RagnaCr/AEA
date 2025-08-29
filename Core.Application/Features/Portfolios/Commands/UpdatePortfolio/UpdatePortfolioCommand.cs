using MediatR;

namespace Core.Application.Features.Portfolios.Commands.UpdatePortfolio;

// Команда несет все необходимые данные для выполнения операции.
public class UpdatePortfolioCommand : IRequest<bool> // Возвращаем bool: true - успешно, false - не найдено.
{
    public Guid PortfolioId { get; set; }
    public Guid UserId { get; set; } // Для проверки прав
    public string NewName { get; set; }
}