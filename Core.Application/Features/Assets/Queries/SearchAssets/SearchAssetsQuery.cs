using Core.Application.Features.Assets.Dtos;
using MediatR;

namespace Core.Application.Features.Assets.Queries.SearchAssets;
public class SearchAssetsQuery : IRequest<List<AssetDto>>
{
    public string SearchText { get; set; }
    public Guid UserId { get; set; } // ID пользователя, чтобы искать и его кастомные активы
    public int Limit { get; set; } = 10; // Ограничим количество результатов
}