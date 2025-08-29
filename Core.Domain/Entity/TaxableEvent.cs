using Core.Domain.Enums;

namespace Core.Domain.Entity;
/// <summary>
/// Эта сущность хранит одну строку налогового отчета — одно налогооблагаемое событие (обычно продажа).
/// </summary>
public class TaxableEvent
{
    public Guid Id { get; private set; }
    public Guid TaxReportId { get; private set; }

    // Ссылка на исходную операцию для трассировки Operation (public Guid Id)
    public Guid SourceOperationId { get; private set; }

    // Данные о событии
    public Guid AssetId { get; private set; }
    public DateTime DateOfDisposal { get; private set; } // Дата продажи
    public decimal QuantityDisposed { get; private set; } // Сколько продано
    public decimal Proceeds { get; private set; } // Выручка от продажи
    public decimal CostBasis { get; private set; } // Рассчитанная себестоимость

    public decimal CapitalGainOrLoss => Proceeds - CostBasis;

    // Важно для правил разных стран (например, США, Австралия)
    public HoldingPeriodType HoldingPeriod { get; private set; } // ShortTerm, LongTerm

    // Приватный конструктор для EF Core
    private TaxableEvent() {}
}