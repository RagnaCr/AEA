using Core.Application.Features.ApiConnections.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.ApiConnections.Commands.Queries.GetApiConnectionById;

public class GetApiConnectionByIdQuery : IRequest<ApiConnectionDto?> // Возвращаем DTO или null
{
    public Guid ConnectionId { get; set; }
    public Guid UserId { get; set; } // Для проверки прав
}