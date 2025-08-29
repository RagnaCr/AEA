using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.ApiConnections.Commands.Delete;
public class DeleteApiConnectionCommand : IRequest<bool>
{
    public Guid ConnectionId { get; set; }
    public Guid UserId { get; set; }
}