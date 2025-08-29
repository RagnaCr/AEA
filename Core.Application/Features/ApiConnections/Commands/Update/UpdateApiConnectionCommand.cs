using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.ApiConnections.Commands.Update;
public class UpdateApiConnectionCommand : IRequest<bool>
{
    public Guid ConnectionId { get; set; }
    public Guid UserId { get; set; } // Для проверки прав
    public string ConnectionName { get; set; }
    public string ApiKey { get; set; }
    public string? ApiSecret { get; set; }
}