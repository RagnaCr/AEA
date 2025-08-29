using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.ApiConnections.Commands.Create;
public class CreateApiConnectionCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string ConnectionName { get; set; }
    public string ExchangeName { get; set; }
    public string ApiKey { get; set; }
    public string? ApiSecret { get; set; }
}