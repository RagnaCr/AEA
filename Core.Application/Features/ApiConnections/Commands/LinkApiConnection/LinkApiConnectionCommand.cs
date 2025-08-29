using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.ApiConnections.Commands.LinkApiConnection;

// Команда, которая не возвращает данных
public class LinkApiConnectionCommand : IRequest
{
    public Guid PortfolioId { get; set; }
    public Guid ConnectionId { get; set; }
    public Guid UserId { get; set; } // Для проверки прав на ОБА объекта
}