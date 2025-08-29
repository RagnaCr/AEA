using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.Portfolios.Dtos;
public class BalanceDto
{
    public Guid AssetId { get; set; }
    public string AssetTicker { get; set; }
    public string AssetName { get; set; }
    public decimal TotalQuantity { get; set; }
}