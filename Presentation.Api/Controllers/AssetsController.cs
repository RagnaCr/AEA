using Core.Application.Features.Assets.Commands.CreateCustomAsset;
using Core.Application.Features.Assets.Queries.SearchAssets;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AssetsController : ControllerBase
{
    private readonly ISender _mediator;

    public AssetsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("search")] // Отвечает на GET /api/assets/search?searchText=...
    public async Task<IActionResult> Search([FromQuery] string searchText)
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdString, out var userId))
        {
            return Unauthorized();
        }

        if (string.IsNullOrWhiteSpace(searchText) || searchText.Length < 2)
        {
            return Ok(new List<object>()); // Возвращаем пустой список, если строка поиска слишком короткая
        }
        
        var query = new SearchAssetsQuery
        {
            SearchText = searchText,
            UserId = userId
        };

        var result = await _mediator.Send(query);
        return Ok(result);
    }
    [HttpPost("custom")] // Отвечает на POST /api/assets/custom
    public async Task<IActionResult> CreateCustom([FromBody] CreateCustomAssetRequest request)
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdString, out var userId))
        {
            return Unauthorized();
        }

        var command = new CreateCustomAssetCommand
        {
            UserId = userId,
            Ticker = request.Ticker,
            Name = request.Name,
            AssetClass = request.AssetClass,
            Sector = request.Sector,
            Industry = request.Industry,
            CountryCode = request.CountryCode
        };

        try
        {
            var assetId = await _mediator.Send(command);
            return CreatedAtAction(nameof(Search), new { searchText = command.Ticker }, new { id = assetId });
        }
        catch (InvalidOperationException ex)
        {
            // Простой способ обработать нашу ошибку уникальности
            return Conflict(new { message = ex.Message });
        }
    }
}