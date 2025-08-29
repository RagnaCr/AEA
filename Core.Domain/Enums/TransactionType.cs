
namespace Core.Domain.Enums;
public enum TransactionType
{
    Unknown,
    Trade,        // Торговая сделка
    Fee,          // Комиссия
    Tax,          // Налог
    Interest,     // Проценты
    Dividend,     // Дивиденды
    Deposit,      // Пополнение
    Withdrawal,   // Вывод
    Airdrop,      // Эирдроп
    FxConversion, // Конвертация валют

    // Дополнительные типы из Questrade
    Transfer,         // Перевод активов
    CorporateAction,  // Корпоративное действие
    Journal,          // Внутренний перевод (например, BRW у Questrade)
}