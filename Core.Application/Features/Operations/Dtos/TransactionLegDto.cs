using Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.Operations.Dtos;

public class TransactionLegDto
{
    public string AssetTicker { get; set; }
    public string AssetName { get; set; }
    public TransactionType Type { get; set; }
    public decimal Quantity { get; set; }
    public int Direction { get; set; }
    public decimal? PricePerUnit { get; set; }
    public string? PriceCurrencyTicker { get; set; }
}