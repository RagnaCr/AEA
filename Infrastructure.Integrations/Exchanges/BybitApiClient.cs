using Bybit.Net.Clients;
using Bybit.Net.Enums;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Interfaces.Exchanges;
using Core.Domain.Entity;
using CryptoExchange.Net.Authentication;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Integrations.Exchanges;

public class BybitApiClient : IExchangeApiClient
{
    private readonly ILogger<BybitApiClient> _logger;
    private readonly IDataProtectionService _dataProtectionService;
    public string ExchangeName => "Bybit";

    public BybitApiClient(ILogger<BybitApiClient> logger, IDataProtectionService dataProtectionService)
    {
        _logger = logger;
        _dataProtectionService = dataProtectionService;
    }

    public async Task<IEnumerable<ExchangeTransaction>> GetTransactionsAsync(ApiConnection connection)
    {
        var apiKey = _dataProtectionService.Decrypt(connection.EncryptedKey1);
        var apiSecret = _dataProtectionService.Decrypt(connection.EncryptedKey2!);

        var bybitClient = new BybitRestClient(options =>
        {
            options.ApiCredentials = new ApiCredentials(apiKey, apiSecret);
        });

        // история сделок (Trade History)
        var tradeHistoryResult = await bybitClient.V5Api.Trading.GetOrderHistoryAsync(Category.Spot); // Spot торги

        if (!tradeHistoryResult.Success)
        {
            _logger.LogError("Failed to get trade history from Bybit: {Error}", tradeHistoryResult.Error?.Message);
            throw new InvalidOperationException($"Bybit API error: {tradeHistoryResult.Error?.Message}");
        }

        if (tradeHistoryResult.Data.List == null) return Enumerable.Empty<ExchangeTransaction>();

        // Преобразуем ответ от Bybit в наш универсальный формат ExchangeTransaction
        return tradeHistoryResult.Data.List.Select(trade => new ExchangeTransaction(
            trade.OrderId,
            trade.CreateTime,
            trade.Side.ToString(),
            $"Order Price: {trade.AveragePrice}, Executed Qty: {trade.QuantityFilled}",
            trade // Сохраняем весь объект как RawData
        ));
    }
}