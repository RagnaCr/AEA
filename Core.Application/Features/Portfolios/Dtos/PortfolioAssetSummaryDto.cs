using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.Portfolios.Dtos
{
    public class PortfolioAssetSummaryDto
    {
        public Guid AssetId { get; set; }
        public string Ticker { get; set; }
        public decimal Quantity { get; set; }
        public decimal? CurrentPrice { get; set; }
        public string? PriceCurrency { get; set; }
        public decimal? TotalValue { get; set; } // Quantity * CurrentPrice
    }
}
