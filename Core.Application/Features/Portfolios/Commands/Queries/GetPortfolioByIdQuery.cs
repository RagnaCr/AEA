using Core.Application.Features.Auth.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.Portfolios.Commands.Queries;

// Запрос несет в себе два параметра: ID портфеля и ID пользователя для проверки прав
public class GetPortfolioByIdQuery : IRequest<PortfolioDto?> // Возвращает DTO или null, если не найдено
{
    public Guid PortfolioId { get; set; }
    public Guid UserId { get; set; }
}