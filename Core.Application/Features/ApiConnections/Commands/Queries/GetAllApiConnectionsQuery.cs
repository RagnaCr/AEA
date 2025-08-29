using Core.Application.Features.ApiConnections.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.ApiConnections.Commands.Queries;
public class GetAllApiConnectionsQuery : IRequest<List<ApiConnectionDto>>
{
    public Guid UserId { get; set; }
}