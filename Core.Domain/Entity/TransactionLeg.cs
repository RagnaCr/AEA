using Core.Domain.Enums;

namespace Core.Domain.Entity;
/// <summary>
/// Класс отвечающий за единицу действия в транзакции,
/// нужен для сохранения данных о транзакция и рассчета корректных метрик
/// </summary>
public class TransactionLeg
{
    public Guid Id { get; private set; }
    public Guid OperationId { get; private set; }
    public Guid AssetId { get; private set; } // Всегда ссылается на наш глобальный справочник Asset
    public TransactionType Type { get; private set; }
    public decimal Quantity { get; private set; }
    public int Direction { get; private set; } // +1 или -1
    public decimal? PricePerUnit { get; private set; } // Цена за единицу актива
    public Guid? PriceCurrencyId { get; private set; } // В какой валюте была цена (FK на Asset)

    // Навигационные свойства для EF Core, чтобы .Include() работал
    public Asset Asset { get; private set; }
    public Asset? PriceCurrency { get; private set; }
    public Operation Operation { get; private set; }

    public decimal SignedQuantity => Quantity * Direction;

    private TransactionLeg() { }

    public TransactionLeg(Guid operationId, Guid assetId, TransactionType type, decimal quantity, int direction, decimal? pricePerUnit = null, Guid? priceCurrencyId = null)
    {
        Id = Guid.NewGuid();

        if (quantity <= 0) throw new ArgumentException("Quantity must be positive.", nameof(quantity));
        if (direction != 1 && direction != -1) throw new ArgumentException("Direction must be 1 or -1.", nameof(direction));

        OperationId = operationId;
        AssetId = assetId;
        Type = type;
        Quantity = quantity;
        Direction = direction;

        PricePerUnit = pricePerUnit;
        PriceCurrencyId = priceCurrencyId;
    }
}
