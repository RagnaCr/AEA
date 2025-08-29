using Core.Application.Common.Interfaces;
using Core.Domain.Entity;
using Core.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.V5;
using System.Text.Json;
using Core.Application.Common.Interfaces.Exchanges;
using System.Text.RegularExpressions;

namespace Core.Application.Features.Operations.Commands.ProcessExchangeTransactions;

public class ProcessExchangeTransactionsCommandHandler : IRequestHandler<ProcessExchangeTransactionsCommand>
{
    private readonly IApplicationDbContext _context;

    public ProcessExchangeTransactionsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(ProcessExchangeTransactionsCommand request, CancellationToken cancellationToken)
    {
        var portfolioIds = await _context.PortfolioApiConnections
            .Where(pac => pac.ApiConnectionId == request.ApiConnectionId)
            .Select(pac => pac.PortfolioId)
            .ToListAsync(cancellationToken);

        if (!portfolioIds.Any()) return Unit.Value;

        var connection = await _context.ApiConnections.FindAsync(request.ApiConnectionId);
        if (connection == null) return Unit.Value;

        var sourceType = Enum.Parse<DataSourceType>(connection.ExchangeName, true);

        // Получаем ID уже существующих в базе операций для данного источника
        var existingTransactionIdList = await _context.Operations
            .Where(o => o.Source == sourceType && o.SourceOperationId != null)
            .Select(o => o.SourceOperationId!)
            .ToListAsync(cancellationToken);

        var existingTransactionIds = new HashSet<string>(existingTransactionIdList);

        // Фильтруем транзакции, оставляя только те, которых еще нет в нашей базе
        var newTransactions = request.Transactions
            .Where(t => !existingTransactionIds.Contains(t.TransactionId))
            .ToList();

        if (!newTransactions.Any()) return Unit.Value;

        var assetDictionary = await GetOrCreateAssetsFromTransactionsAsync(newTransactions, sourceType, cancellationToken);
        var newOperations = new List<Operation>();
        var portfolioId = portfolioIds.First(); // Для простоты берем первый портфель

        if (sourceType == DataSourceType.Questrade)
        {
            var questradeActivities = newTransactions;

            // --- ШАГ 1: Группировка и обработка сложных операций (FX Conversion) ---
            var fxGroups = questradeActivities
                .Where(t => t.Type == "FX conversion")
                .GroupBy(t => t.Timestamp.Date) // Группируем по дню
                .ToList();

            foreach (var group in fxGroups)
            {
                var opDate = group.First().Timestamp;
                // Групповая операция получает свой уникальный ID
                var opId = $"FX-{opDate:o}";
                var opNotes = $"FX Conversion on {opDate.ToShortDateString()}";
                var rawDataJson = JsonSerializer.Serialize(group.Select(g => g.RawData));
                var operation = new Operation(portfolioId, sourceType, opId, opDate, opNotes, rawDataJson);

                foreach (var exTransaction in group)
                {
                    var activity = (JsonElement)exTransaction.RawData;
                    var currency = activity.GetProperty("currency").GetString()!;
                    var amount = activity.GetProperty("netAmount").GetDecimal();
                    if (assetDictionary.TryGetValue(currency, out var asset))
                    {
                        operation.AddLeg(new TransactionLeg(operation.Id, asset.Id, TransactionType.FxConversion, Math.Abs(amount), amount > 0 ? 1 : -1));
                    }
                }
                operation.MarkAsProcessed();
                newOperations.Add(operation);
            }

            // --- ШАГ 2: Обработка всех остальных операций поодиночке ---

            // Получаем ID уже обработанных в группе транзакций, чтобы не трогать их снова
            var processedInGroupIds = fxGroups.SelectMany(g => g.Select(i => i.TransactionId)).ToHashSet();
            var remainingActivities = questradeActivities.Where(t => !processedInGroupIds.Contains(t.TransactionId)).ToList();

            foreach (var exTransaction in remainingActivities)
            {
                // Передаем весь объект ExchangeTransaction в маппер
                var operation = MapQuestradeActivity(portfolioId, exTransaction, assetDictionary);
                if (operation != null)
                {
                    newOperations.Add(operation);
                }
            }
        }
        else if (sourceType == DataSourceType.Bybit)
        {
            foreach (var exTransaction in newTransactions)
            {
                if (exTransaction.RawData is BybitOrder bybitOrder)
                {
                    var operation = MapBybitTrade(portfolioId, bybitOrder, assetDictionary);
                    if (operation != null) newOperations.Add(operation);
                }
            }
        }

        if (newOperations.Any())
        {
            // Финальная проверка на дубликаты перед вставкой (на случай, если групповой ID уже есть)
            var finalOpIds = newOperations.Select(o => o.SourceOperationId).ToHashSet();
            var existingInDb = await _context.Operations
                .Where(o => o.Source == sourceType && finalOpIds.Contains(o.SourceOperationId))
                .Select(o => o.SourceOperationId)
                .ToListAsync(cancellationToken);

            var opsToInsert = newOperations.Where(o => !existingInDb.Contains(o.SourceOperationId)).ToList();

            if (opsToInsert.Any())
            {
                await _context.Operations.AddRangeAsync(opsToInsert, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        return Unit.Value;
    }
    //public async Task<Unit> Handle(ProcessExchangeTransactionsCommand request, CancellationToken cancellationToken)
    //{
    //    var portfolioIds = await _context.PortfolioApiConnections
    //        .Where(pac => pac.ApiConnectionId == request.ApiConnectionId)
    //        .Select(pac => pac.PortfolioId)
    //        .ToListAsync(cancellationToken);

    //    if (!portfolioIds.Any()) return Unit.Value;

    //    var connection = await _context.ApiConnections.FindAsync(request.ApiConnectionId);
    //    if (connection == null) return Unit.Value;

    //    var sourceType = Enum.Parse<DataSourceType>(connection.ExchangeName, true);

    //    // --- ОПТИМИЗАЦИЯ: ПРОВЕРКА ДУБЛИКАТОВ ---
    //    var existingTransactionIdList = await _context.Operations
    //        .Where(o => o.Source == DataSourceType.Bybit && o.SourceOperationId != null) // Добавим проверку на null для надежности
    //        .Select(o => o.SourceOperationId!) // Используем !, чтобы сказать компилятору, что мы уверены, что null отфильтрован
    //        .ToListAsync(cancellationToken);

    //    var existingTransactionIds = new HashSet<string>(existingTransactionIdList);

    //    var newTransactions = request.Transactions.Where(t => !existingTransactionIds.Contains(t.TransactionId)).ToList();
    //    if (!newTransactions.Any()) return Unit.Value;

    //    var assetDictionary = await GetOrCreateAssetsFromTransactionsAsync(newTransactions, sourceType, cancellationToken);
    //    var newOperations = new List<Operation>();

    //    foreach (var exTransaction in newTransactions)
    //    {
    //        Operation? operation = null;
    //        if (sourceType == DataSourceType.Bybit && exTransaction.RawData is BybitOrder bybitOrder)
    //        {
    //            operation = MapBybitTrade(portfolioIds.First(), bybitOrder, assetDictionary);
    //        }
    //        else if (sourceType == DataSourceType.Questrade && exTransaction.RawData is JsonElement questradeActivity)
    //        {
    //            operation = MapQuestradeActivity(portfolioIds.First(), questradeActivity, assetDictionary);
    //        }

    //        if (operation != null) newOperations.Add(operation);
    //    }

    //    if (newOperations.Any())
    //    {
    //        await _context.Operations.AddRangeAsync(newOperations, cancellationToken);
    //        await _context.SaveChangesAsync(cancellationToken);
    //    }

    //    return Unit.Value;
    //}

    private Operation? MapBybitTrade(Guid portfolioId, BybitOrder bybitOrder, Dictionary<string, Asset> assetDictionary)
    {
        var operation = new Operation(portfolioId, DataSourceType.Bybit, bybitOrder.OrderId, bybitOrder.UpdateTime, $"Bybit Order: {bybitOrder.Symbol}", JsonSerializer.Serialize(bybitOrder));

        string baseTicker = "", quoteTicker = "";
        if (bybitOrder.Symbol.EndsWith("USDT"))
        {
            baseTicker = bybitOrder.Symbol.Replace("USDT", "");
            quoteTicker = "USDT";
        }
        else { /* TODO: Add other pairs */ }

        if (string.IsNullOrEmpty(baseTicker) || !assetDictionary.TryGetValue(baseTicker, out var baseAsset) || !assetDictionary.TryGetValue(quoteTicker, out var quoteAsset) || bybitOrder.QuantityFilled is null or 0)
        {
            operation.MarkForReview($"Unsupported symbol or not filled: {bybitOrder.Symbol}");
            return operation;
        }

        operation.AddLeg(new TransactionLeg(operation.Id, baseAsset.Id, TransactionType.Trade, bybitOrder.QuantityFilled.Value, bybitOrder.Side == OrderSide.Buy ? 1 : -1));
        operation.AddLeg(new TransactionLeg(operation.Id, quoteAsset.Id, TransactionType.Trade, bybitOrder.ValueFilled!.Value, bybitOrder.Side == OrderSide.Buy ? -1 : 1));

        if (bybitOrder.ExecutedFee > 0 && !string.IsNullOrEmpty(bybitOrder.FeeAsset) && assetDictionary.TryGetValue(bybitOrder.FeeAsset, out var feeAsset))
        {
            operation.AddLeg(new TransactionLeg(operation.Id, feeAsset.Id, TransactionType.Fee, bybitOrder.ExecutedFee.Value, -1));
        }

        operation.MarkAsProcessed();
        return operation;
    }

    private Operation? MapQuestradeActivity(Guid portfolioId, ExchangeTransaction exTransaction, Dictionary<string, Asset> assetDictionary)
    {
        var activity = (JsonElement)exTransaction.RawData;
        var netAmount = activity.GetProperty("netAmount").GetDecimal();

        // Создаем операцию, используя готовые данные из exTransaction
        var operation = new Operation(portfolioId, DataSourceType.Questrade, exTransaction.TransactionId, exTransaction.Timestamp, exTransaction.Notes, activity.ToString());

        var currencyTicker = activity.GetProperty("currency").GetString()!;
        if (!assetDictionary.TryGetValue(currencyTicker, out var currencyAsset))
        {
            operation.MarkForReview($"Currency asset '{currencyTicker}' not found.");
            return operation;
        }

        switch (exTransaction.Type)
        {
            case "Trades":
                return MapTrade(operation, activity, assetDictionary, currencyAsset);

            case "Dividends":
                if (netAmount <= 0) return null; // Игнорируем списания дивидендов или нулевые

                var divSymbol = activity.GetProperty("symbol").GetString();
                if (string.IsNullOrEmpty(divSymbol))
                {
                    var match = Regex.Match(exTransaction.Notes!, @"\b([A-Z]{1,5}(\.[A-Z]{1,2})?)\b");
                    if (match.Success) divSymbol = match.Groups[1].Value;
                }
                if (!string.IsNullOrEmpty(divSymbol))
                {
                    // Используем новый метод для добавления заметок
                    operation.SetNotes($"Dividend from {divSymbol}");
                }

                operation.AddLeg(new TransactionLeg(operation.Id, currencyAsset.Id, TransactionType.Dividend, netAmount, 1));
                operation.MarkAsProcessed();
                return operation;

            case "Deposits":
                if (netAmount <= 0) return null;
                operation.AddLeg(new TransactionLeg(operation.Id, currencyAsset.Id, TransactionType.Deposit, netAmount, 1));
                operation.MarkAsProcessed();
                return operation;

            case "Withdrawals":
                if (netAmount >= 0) return null;
                operation.AddLeg(new TransactionLeg(operation.Id, currencyAsset.Id, TransactionType.Withdrawal, Math.Abs(netAmount), -1));
                operation.MarkAsProcessed();
                return operation;

            case "Fees and rebates":
                if (netAmount >= 0) return null;
                operation.AddLeg(new TransactionLeg(operation.Id, currencyAsset.Id, TransactionType.Fee, Math.Abs(netAmount), -1));
                operation.MarkAsProcessed();
                return operation;

            case "Corporate actions":
                if (netAmount > 0) // Пример: CIL - Cash in lieu (деньги вместо дробной акции)
                {
                    operation.AddLeg(new TransactionLeg(operation.Id, currencyAsset.Id, TransactionType.Trade, netAmount, 1));
                    operation.MarkAsProcessed();
                    return operation;
                }
                operation.MarkForReview($"Unsupported corporate action: {exTransaction.Notes}");
                return operation;

            // Эти типы обрабатываются в группах или требуют специальной логики.
            // Здесь мы их игнорируем или помечаем для разбора.
            case "FX conversion": // Уже обработан в группе
            case "Other":         // Например, Journal ("BRW"), пока игнорируем
                return null;

            default:
                operation.MarkForReview($"Unsupported activity type: '{exTransaction.Type}'");
                return operation;
        }
    }

    private Operation? MapTrade(Operation operation, JsonElement activity, Dictionary<string, Asset> assetDictionary, Asset currencyAsset)
    {
        var action = activity.GetProperty("action").GetString()!; // Buy or Sell
        var quantity = activity.GetProperty("quantity").GetDecimal();
        var commission = activity.GetProperty("commission").GetDecimal();
        var netAmount = activity.GetProperty("netAmount").GetDecimal();
        var description = activity.GetProperty("description").GetString()!;

        // Получаем тикер акции/ETF
        var ticker = activity.GetProperty("symbol").GetString();
        if (string.IsNullOrEmpty(ticker))
        {
            // Иногда тикер пуст, извлекаем его из описания
            var match = Regex.Match(description, @"\b([A-Z]{1,5}(\.[A-Z]{1,2})?)\b");
            if (match.Success)
            {
                ticker = match.Groups[1].Value;
            }
            else
            {
                operation.MarkForReview($"Could not determine ticker from description: {description}");
                return operation;
            }
        }

        if (!assetDictionary.TryGetValue(ticker, out var tradeAsset))
        {
            operation.MarkForReview($"Trade asset '{ticker}' not found.");
            return operation;
        }

        // 1. Нога с основным активом (акция, ETF)
        var direction = action == "Buy" ? 1 : -1;
        operation.AddLeg(new TransactionLeg(operation.Id, tradeAsset.Id, TransactionType.Trade, Math.Abs(quantity), direction));

        // 2. Нога с деньгами
        operation.AddLeg(new TransactionLeg(operation.Id, currencyAsset.Id, TransactionType.Trade, Math.Abs(netAmount), -direction));

        // 3. Нога с комиссией (если она есть)
        if (commission != 0)
        {
            operation.AddLeg(new TransactionLeg(operation.Id, currencyAsset.Id, TransactionType.Fee, Math.Abs(commission), -1));
        }

        operation.MarkAsProcessed();
        return operation;
    }

    private async Task<Dictionary<string, Asset>> GetOrCreateAssetsFromTransactionsAsync(List<ExchangeTransaction> transactions, DataSourceType source, CancellationToken cancellationToken)
    {
        var requiredTickers = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        if (source == DataSourceType.Bybit)
        {
            foreach (var t in transactions.Select(t => t.RawData as BybitOrder).Where(bo => bo != null))
            {
                if (t.Symbol.EndsWith("USDT")) { requiredTickers.Add(t.Symbol.Replace("USDT", "")); requiredTickers.Add("USDT"); }
                if (!string.IsNullOrEmpty(t.FeeAsset)) requiredTickers.Add(t.FeeAsset);
            }
        }
        else if (source == DataSourceType.Questrade)
        {
            foreach (var t in transactions)
            {
                var activity = (JsonElement)t.RawData;

                // 1. Добавляем валюту операции
                requiredTickers.Add(activity.GetProperty("currency").GetString()!);

                // 2. Добавляем тикер из поля 'symbol', если он есть
                var tickerFromSymbolField = activity.GetProperty("symbol").GetString();
                if (!string.IsNullOrEmpty(tickerFromSymbolField))
                {
                    requiredTickers.Add(tickerFromSymbolField);
                }

                // 3. Добавляем тикер из описания (используя t.Notes или t.Description)
                // Важно, чтобы регулярное выражение было здесь таким же, как в MapTrade.
                if (t.Type == "Trades" && !string.IsNullOrEmpty(t.Notes))
                {
                    var tickerFromDesc = Regex.Match(t.Notes, @"\b([A-Z]{1,5}(\.[A-Z]{1,2})?)\b").Groups[1].Value;
                    if (!string.IsNullOrEmpty(tickerFromDesc))
                    {
                        requiredTickers.Add(tickerFromDesc);
                    }
                }
            }
        }

        requiredTickers.RemoveWhere(string.IsNullOrEmpty);
        if (!requiredTickers.Any()) return new Dictionary<string, Asset>();

        var existingAssets = await _context.Assets.Where(a => requiredTickers.Contains(a.Ticker)).ToDictionaryAsync(a => a.Ticker, StringComparer.OrdinalIgnoreCase, cancellationToken);
        var assetsToCreate = new List<Asset>();

        foreach (var ticker in requiredTickers)
        {
            if (!existingAssets.ContainsKey(ticker))
            {
                var newAsset = new Asset(ticker, ticker, DetermineAssetClass(ticker)); // Имя пока = тикер
                assetsToCreate.Add(newAsset);
                existingAssets[ticker] = newAsset;
            }
        }

        if (assetsToCreate.Any())
        {
            await _context.Assets.AddRangeAsync(assetsToCreate, cancellationToken);
        }

        return existingAssets;
    }

    private AssetClass DetermineAssetClass(string ticker)
    {
        if (ticker.Contains('.') || new[] { "VTI", "VOO", "SPY" }.Contains(ticker)) return AssetClass.Etf;
        if (ticker is "USD" or "CAD" or "EUR" or "USDT" or "USDC") return AssetClass.Cash;
        // Простая проверка, если нет точек и не фиат - скорее всего акция или крипта
        if (ticker.Length <= 4) return AssetClass.Stock;
        return AssetClass.Crypto;
    }
}