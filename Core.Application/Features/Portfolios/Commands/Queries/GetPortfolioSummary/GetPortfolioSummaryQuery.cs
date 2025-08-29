using Core.Application.Features.Portfolios.Dtos;
using MediatR;

namespace Core.Application.Features.Portfolios.Commands.Queries.GetPortfolioSummary
{
    public class GetPortfolioSummaryQuery : IRequest<PortfolioSummaryDto>
    {
        public Guid PortfolioId { get; set; }
        public Guid UserId { get; set; }
    }
}
