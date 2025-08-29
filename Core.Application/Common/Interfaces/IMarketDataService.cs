using Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Common.Interfaces;

// DTO для ответа
public record MarketPrice(string Ticker, decimal Price, string Currency);

public interface IMarketDataService
{
    // Метод будет принимать список тикеров и API-ключи пользователя (в виде ApiConnection)
    // и возвращать для них цены.
    Task<List<MarketPrice>> GetCurrentPricesAsync(IEnumerable<ApiConnection> connections, IEnumerable<string> tickers);
}