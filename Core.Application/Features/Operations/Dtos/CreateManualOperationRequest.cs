using Core.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Application.Features.Operations.Dtos;
public class CreateManualOperationRequest
{
    [Required]
    public OperationType Type { get; set; }

    [Required]
    public DateTime Timestamp { get; set; }

    public string? Notes { get; set; }

    [Required]
    [MinLength(1)]
    public List<TransactionLegRequest> Legs { get; set; } = new();
}