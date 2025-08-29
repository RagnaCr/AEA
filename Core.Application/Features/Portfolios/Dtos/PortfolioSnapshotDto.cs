using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.Portfolios.Dtos;
public class PortfolioSnapshotDto
{
    public DateTime Date { get; set; }
    public decimal MarketValue { get; set; }
}