using Core.Domain.Enums;

namespace Core.Domain.Entity;

/// <summary>
/// Asset базовый класс реализующий логику кастомных и не кастомных токенов от юзера, те которые будут официальные будут получены 
/// из официальных апи, кастомные будут видны только для юзера который их добавил 
/// (будет добавлять свои транзакции и есть не найдет в списке нужные токен добавит свой который и будет оперделен как кастомный)
/// ТАК ЖЕ НУЖНО ДО ПРОДА НУЖНО ЗАПОЛНИТЬ ASSET МАКСИМАЛЬНЫМ КОЛИЧЕСТВОМ ДАННЫХ ВО ИЗБЕЖАНИЕ ДУБЛИРОВАНИЯ ИНФОРМАЦИИ
/// И ЕЩЕ НА ЭТАПЕ ТЕСТИРОВАНИЯ ЗАПОЛНИТЬ ASSET ОФИЦИАЛЬНЫМИ ВАЛЮТАМИ ВСЕГО МИРА ПРИМЕР:
/// new Asset("USD", "US Dollar", AssetClass.Cash); // UserId = null
/// new Asset("EUR", "Euro", AssetClass.Cash);      // UserId = null
/// new Asset("CAD", "Canadian Dollar", AssetClass.Cash); // UserId = null
/// </summary>
public class Asset
{
    public Guid Id { get; private set; }
    public string Ticker { get; private set; }
    public string Name { get; private set; }
    public AssetClass AssetClass { get; private set; }
    public string? Sector { get; private set; }
    public string? Industry { get; private set; }
    public string? CountryCode { get; private set; } // "US", "DE" и т.д.

    public bool IsCustom { get; private set; } // true, если актив создан пользователем
    public Guid? UserId { get; private set; } // ID пользователя, который создал кастомный актив. Null для глобальных.

    private Asset() { }

    // Конструктор для глобальных активов
    public Asset(string ticker, string name, AssetClass assetClass)
    {
        Id = Guid.NewGuid();
        Ticker = ticker;
        Name = name;
        AssetClass = assetClass;
        IsCustom = false;
        UserId = null;
    }

    // Фабричный метод для создания кастомных активов
    public static Asset CreateCustom(Guid userId, string ticker, string name, AssetClass assetClass,
                                      string? sector = null, string? industry = null, string? countryCode = null)
    {
        return new Asset
        {
            Id = Guid.NewGuid(),
            Ticker = ticker,
            Name = name,
            AssetClass = assetClass,
            IsCustom = true,
            UserId = userId,
            Sector = sector,
            Industry = industry,
            CountryCode = countryCode
        };
    }
}
