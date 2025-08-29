
namespace Core.Domain.Entity;
/// <summary>
/// Связующая таблица
/// </summary>
public class TaxReportPortfolio
{
    public Guid TaxReportId { get; set; }
    public Guid PortfolioId { get; set; }
    private TaxReportPortfolio() { }
    public TaxReportPortfolio(Guid taxReportId, Guid portfolioId)
    {
        TaxReportId = taxReportId;
        PortfolioId = portfolioId;
    }
}
