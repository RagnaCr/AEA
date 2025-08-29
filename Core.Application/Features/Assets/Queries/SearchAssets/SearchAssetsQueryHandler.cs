using Core.Application.Common.Interfaces;
using Core.Application.Features.Assets.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.Assets.Queries.SearchAssets;

public class SearchAssetsQueryHandler : IRequestHandler<SearchAssetsQuery, List<AssetDto>>
{
    private readonly IApplicationDbContext _context;

    public SearchAssetsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<AssetDto>> Handle(SearchAssetsQuery request, CancellationToken cancellationToken)
    {
        var searchTextLower = request.SearchText.ToLower();

        var assets = await _context.Assets
            // Фильтруем сразу
            .Where(a =>
                // Условие видимости
                (a.IsCustom == false || a.UserId == request.UserId)
                &&
                // Условие поиска: либо Ticker начинается с запроса, либо Name
                (a.Ticker.ToLower().StartsWith(searchTextLower) || a.Name.ToLower().StartsWith(searchTextLower))
            )
            // Сортировка нужна для консистентного порядка, но она уже не такая сложная
            .OrderBy(a => a.Ticker)
            .Take(request.Limit)
            .Select(a => new AssetDto
            {
                Id = a.Id,
                Ticker = a.Ticker,
                Name = a.Name,
                AssetClass = a.AssetClass,
                IsCustom = a.IsCustom,
                Sector = a.Sector,
                Industry = a.Industry,
                CountryCode = a.CountryCode
            })
            .ToListAsync(cancellationToken);

        return assets;

        return assets;
    }
}