using Core.Application.Features.Portfolios.Dtos;
using MediatR;

namespace Core.Application.Features.Portfolios.Commands.Queries.GetPortfolioBalances;

public class GetPortfolioBalancesQuery : IRequest<List<BalanceDto>>
{
    public Guid PortfolioId { get; set; }
    public Guid UserId { get; set; } // Для проверки прав
}