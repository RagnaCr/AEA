using Core.Application.Common.Interfaces;
using Core.Domain.Entity;
using Core.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.Operations.Commands.CreateManualOperation;

public class CreateManualOperationCommandHandler : IRequestHandler<CreateManualOperationCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateManualOperationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateManualOperationCommand request, CancellationToken cancellationToken)
    {
        // 1. Проверка прав собственности на портфель
        var portfolio = await _context.Portfolios
            .FirstOrDefaultAsync(p => p.Id == request.PortfolioId && p.UserId == request.UserId, cancellationToken);
        if (portfolio == null)
        {
            throw new UnauthorizedAccessException("Portfolio not found or user does not have access.");
        }

        // 2. Создаем родительскую операцию
        var operation = new Operation(
            portfolio.Id,
            DataSourceType.Manual, // Источник - ручной ввод
            $"manual-{Guid.NewGuid()}", // Уникальный ID для ручной операции
            request.OperationRequest.Timestamp.ToUniversalTime(),
            request.OperationRequest.Notes
        );

        // 3. Обрабатываем "ноги" транзакции
        foreach (var legRequest in request.OperationRequest.Legs)
        {
            // 3.1. Находим AssetId
            var asset = await FindAssetAsync(legRequest.AssetTicker, request.UserId, legRequest.IsCustomAsset, cancellationToken);

            // 3.2. Находим PriceCurrencyId, если указана цена
            Guid? priceCurrencyId = null;
            if (legRequest.PricePerUnit.HasValue && !string.IsNullOrEmpty(legRequest.PriceCurrencyTicker))
            {
                var currencyAsset = await FindAssetAsync(legRequest.PriceCurrencyTicker, request.UserId, false, cancellationToken);
                priceCurrencyId = currencyAsset.Id;
            }

            // 3.3. Создаем "ногу"
            var leg = new TransactionLeg(
                operation.Id,
                asset.Id,
                legRequest.Type,
                legRequest.Quantity,
                legRequest.Direction,
                legRequest.PricePerUnit,
                priceCurrencyId
            );

            // 3.4. Добавляем ее к операции
            operation.AddLeg(leg);
        }

        // 4. Сохраняем все в БД
        _context.Operations.Add(operation);
        await _context.SaveChangesAsync(cancellationToken);

        return operation.Id;
    }

    private async Task<Asset> FindAssetAsync(string ticker, Guid userId, bool isCustom, CancellationToken cancellationToken)
    {
        var tickerLower = ticker.ToLower();
        Asset? asset;

        if (isCustom)
        {
            // Ищем кастомный ассет, принадлежащий пользователю
            asset = await _context.Assets
                .FirstOrDefaultAsync(a => a.UserId == userId && a.Ticker.ToLower() == tickerLower, cancellationToken);
        }
        else
        {
            // Ищем глобальный ассет
            asset = await _context.Assets
                .FirstOrDefaultAsync(a => a.IsCustom == false && a.Ticker.ToLower() == tickerLower, cancellationToken);
        }

        if (asset == null)
        {
            throw new KeyNotFoundException($"Asset with ticker '{ticker}' not found.");
        }
        return asset;
    }
}