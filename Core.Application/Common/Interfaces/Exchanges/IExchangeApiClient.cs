using Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Common.Interfaces.Exchanges;

// DTO для универсального представления транзакции с биржи
public record ExchangeTransaction(
    string TransactionId, // Уникальный ID транзакции с биржи
    DateTime Timestamp,
    string Type, // Тип, как его отдает биржа ("BUY", "SELL", "DEPOSIT")
    string Notes,
    object RawData // Оригинальные данные в виде объекта для сохранения в JSON
);

// Интерфейс, который должен будет реализовать каждый наш клиент
public interface IExchangeApiClient
{
    // Название биржи, на которое он будет отзываться
    string ExchangeName { get; }

    // Основной метод для получения транзакций
    Task<IEnumerable<ExchangeTransaction>> GetTransactionsAsync(ApiConnection connection);
}