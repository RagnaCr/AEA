using Core.Application.Common.Interfaces;
using Core.Domain.Entity;

namespace Infrastructure.Integrations.Services;
public class StubMarketDataService : IMarketDataService
{
    public Task<List<MarketPrice>> GetCurrentPricesAsync(IEnumerable<ApiConnection> connections, IEnumerable<string> tickers)
    {
        // Возвращаем жестко закодированные цены для теста
        var prices = new List<MarketPrice>();
        foreach (var ticker in tickers)
        {
            if (ticker == "BTC") prices.Add(new MarketPrice("BTC", 65000.00m, "USD"));
            if (ticker == "ETH") prices.Add(new MarketPrice("ETH", 3500.00m, "USD"));
            if (ticker == "UAH") prices.Add(new MarketPrice("UAH", 0.025m, "USD")); // Цена гривны в долларах
            if (ticker == "USD") prices.Add(new MarketPrice("USD", 1.00m, "USD"));
        }
        return Task.FromResult(prices);
    }
}
