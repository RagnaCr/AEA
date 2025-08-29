using Core.Application.Features.Operations.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.Operations.Queries.GetOperationsByPortfolio;

// Добавим постраничную навигацию для будущего
public class GetOperationsByPortfolioQuery : IRequest<List<OperationDto>>
{
    public Guid PortfolioId { get; set; }
    public Guid UserId { get; set; } // Для проверки прав
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}