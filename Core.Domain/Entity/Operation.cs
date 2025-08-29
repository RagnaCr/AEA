using Core.Domain.Enums;

namespace Core.Domain.Entity;
/// <summary>
/// Класс отвечающий за цельную транзакцию, напрямую связан с портфолио,
/// нужен для сохранения данных о транзакция и рассчета корректных метрик
/// </summary>
public class Operation
{
    public Guid Id { get; private set; } // TaxableEvent ссылается на это свойство через SourceOperationId 
    public Guid PortfolioId { get; private set; }
    public OperationType Type { get; private set; }
    public DataSourceType Source { get; private set; }
    public string SourceOperationId { get; private set; }
    public DateTime Timestamp { get; private set; }
    public string? Notes { get; private set; }

    public OperationStatus Status { get; private set; }
    public string? RawData { get; private set; } // Поле для хранения сырого JSON

    private readonly List<TransactionLeg> _legs = new();
    public IReadOnlyList<TransactionLeg> Legs => _legs.AsReadOnly();

    // Приватный конструктор для EF Core
    private Operation() { }

    // Основной конструктор, который гарантирует целостность
    public Operation(Guid portfolioId, DataSourceType source, string sourceOperationId, DateTime timestamp, string? notes = null, string? rawdata = null)
    {
        Id = Guid.NewGuid();
        PortfolioId = portfolioId;
        Source = source;
        SourceOperationId = sourceOperationId;
        Timestamp = timestamp;
        Notes = notes;
        RawData = rawdata;
    }

    private void UpdateType()
    {
        Type = _legs.Count > 1 ? OperationType.Complex : OperationType.Flat;
    }

    public void SetNotes(string? notes)
    {
        this.Notes = notes;
    }

    /// <summary>
    /// Добавляет "ногу" транзакции к операции.
    /// </summary>
    public void AddLeg(TransactionLeg leg)
    {
        if (leg.OperationId != this.Id)
        {
            throw new InvalidOperationException("Cannot add a leg from another operation.");
        }
        _legs.Add(leg);
        UpdateType();
    }
    public void MarkAsProcessed()
    {
        Status = OperationStatus.Processed;
        // Можно сбросить заметки, если они больше не нужны, но пока нужны :)
        // Notes = null; 
    }

    public void MarkForReview(string reason)
    {
        Status = OperationStatus.RequiresReview;
        Notes = $"[REVIEW NEEDED] {reason}"; // Добавляем причину в заметки
    }

    public void MarkAsFailed(string error)
    {
        Status = OperationStatus.Failed;
        Notes = $"[FAILED] {error}";
    }
}