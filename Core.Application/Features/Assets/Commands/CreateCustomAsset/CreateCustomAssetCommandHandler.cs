using Core.Application.Common.Interfaces;
using Core.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Features.Assets.Commands.CreateCustomAsset;

public class CreateCustomAssetCommandHandler : IRequestHandler<CreateCustomAssetCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateCustomAssetCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateCustomAssetCommand request, CancellationToken cancellationToken)
    {
        // Проверка: не пытается ли пользователь создать кастомный актив с тикером,
        // который уже существует как глобальный.
        var globalAssetExists = await _context.Assets
            .AnyAsync(a => a.IsCustom == false && a.Ticker.ToLower() == request.Ticker.ToLower(), cancellationToken);

        if (globalAssetExists)
        {
            // Здесь можно бросить кастомное исключение, которое потом преобразуется в 409 Conflict
            throw new InvalidOperationException($"A global asset with ticker '{request.Ticker}' already exists.");
        }

        // Используем фабричный метод из нашего доменного класса
        var asset = Asset.CreateCustom(
        request.UserId,
        request.Ticker,
        request.Name,
        request.AssetClass,
        request.Sector,
        request.Industry,
        request.CountryCode
        );

        _context.Assets.Add(asset);
        await _context.SaveChangesAsync(cancellationToken);

        return asset.Id;
    }
}