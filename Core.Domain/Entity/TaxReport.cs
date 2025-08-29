using Core.Domain.Enums;

namespace Core.Domain.Entity;
/// <summary>
/// Эта сущность — главный объект, который создает пользователь. Она описывает, какой отчет он хочет получить.
/// </summary>
public class TaxReport
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }

    public string Name { get; private set; } // Например, "US Taxes 2025" или "Отчет для Канады"
    public int TaxYear { get; private set; } // 2025, 2026 и т.д.
    public string JurisdictionCountryCode { get; private set; } // "US", "CA", "GB"
    public CostBasisMethod CostBasisMethod { get; private set; } // FIFO, ACB, и т.д.

    // Связь многие-ко-многим с портфелями, которые входят в этот отчет
    public ICollection<TaxReportPortfolio> IncludedPortfolios { get; private set; } = new List<TaxReportPortfolio>();

    // Связь один-ко-многим с результатами расчета
    public ICollection<TaxableEvent> TaxableEvents { get; private set; } = new List<TaxableEvent>();

    // Приватный конструктор для EF Core
    private TaxReport() { }
    // Конструктор и методы... будут добавлены когда до этого дойдем :)
}