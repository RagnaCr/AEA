using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.Portfolios.Dtos
{
    public class PortfolioSummaryDto
    {
        public Guid PortfolioId { get; set; }
        public string PortfolioName { get; set; }
        public decimal TotalValue { get; set; } // Суммарная стоимость всех активов
        public string BaseCurrency { get; set; } = "USD"; // Валюта, в которой все посчитано
        public List<PortfolioAssetSummaryDto> Assets { get; set; } = new();
    }
}
