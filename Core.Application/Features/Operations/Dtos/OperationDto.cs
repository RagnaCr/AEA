using Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.Operations.Dtos;

public class OperationDto
{
    public Guid Id { get; set; }
    public OperationType Type { get; set; }
    public DataSourceType Source { get; set; }
    public DateTime Timestamp { get; set; }
    public string? Notes { get; set; }
    public OperationStatus Status { get; set; }
    public List<TransactionLegDto> Legs { get; set; } = new();
}