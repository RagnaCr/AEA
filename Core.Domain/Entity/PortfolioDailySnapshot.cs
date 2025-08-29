
namespace Core.Domain.Entity;

/// <summary>
/// Стоит задача: построить график "История портфеля" и Максимальная Просадка (Max Drawdown)
/// Пытаться на лету пересчитывать стоимость портфеля для каждой из 365 точек на графике? 
/// Это убьет производительность. Так что оптимально иметь эти данные в снэпшотах. 
/// Так же поможет решить проблему при работе с Коэффициентом Шарпа, Альфа и Бета (+другие перспективные метрики).
/// </summary>
public class PortfolioDailySnapshot
{
    public Guid Id { get; set; }
    public Guid PortfolioId { get; set; }
    public DateTime Date { get; set; }
    public decimal MarketValue { get; set; }
    public decimal CostBasis { get; set; }
}
