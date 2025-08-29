using MediatR;

namespace Core.Application.Features.Portfolios.Commands.CreateDailySnapshot;

public class CreateDailySnapshotCommand : IRequest
{
    public Guid PortfolioId { get; set; }
    public DateTime Date { get; set; }
}