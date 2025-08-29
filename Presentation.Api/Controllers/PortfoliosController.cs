// Aggregator.Presentation.Api/Controllers/PortfoliosController.cs
using Core.Application.Features.Auth.Dtos;
using Core.Application.Features.Portfolios.Commands.CreatePortfolio;
using Core.Application.Features.Portfolios.Commands.DeletePortfolio;
using Core.Application.Features.Portfolios.Commands.UpdatePortfolio;
using Core.Application.Features.Portfolios.Commands.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Core.Application.Features.Operations.Commands.CreateManualOperation;
using Core.Application.Features.Operations.Dtos;
using Core.Application.Features.Operations.Queries.GetOperationsByPortfolio;
using Core.Application.Features.Portfolios.Commands.Queries.GetPortfolioBalances;
using Core.Application.Features.Portfolios.Dtos;
using Core.Application.Features.Portfolios.Commands.Queries.GetPortfolioSummary;
using Core.Application.Features.Portfolios.Commands.Queries.GetPortfolioHistory;
using Core.Application.Features.ApiConnections.Commands.LinkApiConnection;
using Core.Application.Features.ApiConnections.Dtos;

namespace Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PortfoliosController : ControllerBase
{
    private readonly ISender _mediator;

    public PortfoliosController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("{portfolioId:guid}/apiconnections")] // POST /api/portfolios/{portfolioId}/apiconnections
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> LinkApiConnection(Guid portfolioId, [FromBody] LinkApiConnectionRequestDto request)
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdString, out var userId))
        {
            return Unauthorized();
        }

        var command = new LinkApiConnectionCommand
        {
            PortfolioId = portfolioId,
            ConnectionId = request.ConnectionId,
            UserId = userId
        };

        try
        {
            await _mediator.Send(command);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }

        return NoContent();
    }

    [HttpPost] // Этот метод будет отвечать на HTTP POST запросы
    [ProducesResponseType(StatusCodes.Status201Created)] // Что мы можем вернуть в случае успеха
    [ProducesResponseType(StatusCodes.Status400BadRequest)] // Что мы можем вернуть в случае ошибки валидации
    [ProducesResponseType(StatusCodes.Status401Unauthorized)] // Добавляем возможный ответ
    public async Task<IActionResult> Create(CreatePortfolioRequest request)
    {
        // Получаем ID пользователя из claims токена
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out var userId))
        {
            return Unauthorized();
        }

        var command = new CreatePortfolioCommand
        {
            Name = request.Name,
            UserId = userId
        };

        var portfolioId = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = portfolioId }, new { id = portfolioId });
    }

    [HttpGet] // Отвечает на GET /api/portfolios
    [ProducesResponseType(typeof(List<PortfolioDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdString, out var userId))
        {
            return Unauthorized();
        }

        var query = new GetAllPortfoliosQuery { UserId = userId };
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{id:guid}")] // Отвечает на GET /api/portfolios/GUID
    [ProducesResponseType(typeof(PortfolioDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdString, out var userId))
        {
            return Unauthorized();
        }

        var query = new GetPortfolioByIdQuery
        {
            PortfolioId = id,
            UserId = userId
        };

        var result = await _mediator.Send(query);

        // Если обработчик вернул null, значит портфель не найден или у пользователя нет к нему доступа.
        // В обоих случаях для безопасности возвращаем 404 Not Found.
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPut("{id:guid}")] // Отвечает на PUT /api/portfolios/GUID
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePortfolioRequest request)
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdString, out var userId))
        {
            return Unauthorized();
        }

        var command = new UpdatePortfolioCommand
        {
            PortfolioId = id,
            UserId = userId,
            NewName = request.Name
        };

        var success = await _mediator.Send(command);

        if (!success)
        {
            return NotFound(); // Если портфель не найден или не принадлежит пользователю
        }

        return NoContent(); // 204 NoContent - стандартный ответ для успешного PUT/DELETE
    }
   
    [HttpDelete("{id:guid}")] // Отвечает на DELETE /api/portfolios/GUID
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdString, out var userId))
        {
            return Unauthorized();
        }

        var command = new DeletePortfolioCommand
        {
            PortfolioId = id,
            UserId = userId
        };

        var success = await _mediator.Send(command);

        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPost("{portfolioId:guid}/operations")] // POST /api/portfolios/{portfolioId}/operations
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> AddManualOperation(Guid portfolioId, [FromBody] CreateManualOperationRequest request)
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdString, out var userId))
        {
            return Unauthorized();
        }

        var command = new CreateManualOperationCommand
        {
            PortfolioId = portfolioId,
            UserId = userId,
            OperationRequest = request
        };

        try
        {
            var operationId = await _mediator.Send(command);
            // В идеале должен быть GET эндпоинт для операции, но пока его нет, вернем просто ID
            return StatusCode(201, new { operationId });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
        catch (KeyNotFoundException ex)
        {
            // Если не найден ассет
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpGet("{portfolioId:guid}/operations")]
    [ProducesResponseType(typeof(List<OperationDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOperations(Guid portfolioId, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdString, out var userId))
        {
            return Unauthorized();
        }

        var query = new GetOperationsByPortfolioQuery
        {
            PortfolioId = portfolioId,
            UserId = userId,
            PageNumber = pageNumber,
            PageSize = pageSize
        };

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{portfolioId:guid}/balances")]
    [ProducesResponseType(typeof(List<BalanceDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBalances(Guid portfolioId)
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdString, out var userId))
        {
            return Unauthorized();
        }

        var query = new GetPortfolioBalancesQuery
        {
            PortfolioId = portfolioId,
            UserId = userId
        };

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{portfolioId:guid}/summary")]
    public async Task<IActionResult> GetSummary(Guid portfolioId)
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdString, out var userId)) return Unauthorized();

        try
        {
            var query = new GetPortfolioSummaryQuery { PortfolioId = portfolioId, UserId = userId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpGet("{portfolioId:guid}/history")]
    [ProducesResponseType(typeof(List<PortfolioSnapshotDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetHistory(Guid portfolioId)
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdString, out var userId))
        {
            return Unauthorized();
        }

        var query = new GetPortfolioHistoryQuery
        {
            PortfolioId = portfolioId,
            UserId = userId
        };

        var result = await _mediator.Send(query);

        return Ok(result);
    }
}