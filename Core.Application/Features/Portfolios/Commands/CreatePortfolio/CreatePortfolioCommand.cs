using MediatR;

namespace Core.Application.Features.Portfolios.Commands.CreatePortfolio;

public class CreatePortfolioCommand : IRequest<Guid> // IRequest<Guid> означает, что команда вернет Guid нового портфеля
{
    // ID пользователя, для которого создается портфель.
    // В будущем мы будем получать его из JWT-токена, а не передавать явно.
    public Guid UserId { get; set; }

    public string Name { get; set; }
}