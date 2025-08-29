using Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.ApiConnections.Dtos;
public class ApiConnectionDto
{
    public Guid Id { get; set; }
    public string ConnectionName { get; set; }
    public string ExchangeName { get; set; }
    public ApiConnectionStatus Status { get; set; }
    public DateTime? LastSuccessfulSync { get; set; }
    public string? LastErrorMessage { get; set; }
}