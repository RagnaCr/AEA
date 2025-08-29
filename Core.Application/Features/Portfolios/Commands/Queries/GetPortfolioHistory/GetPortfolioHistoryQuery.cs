using Core.Application.Features.Portfolios.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.Portfolios.Commands.Queries.GetPortfolioHistory;
public class GetPortfolioHistoryQuery : IRequest<List<PortfolioSnapshotDto>>
{
    public Guid PortfolioId { get; set; }
    public Guid UserId { get; set; } // Для проверки прав
}