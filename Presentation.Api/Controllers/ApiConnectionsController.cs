using Core.Application.Features.ApiConnections.Dtos;
using Core.Application.Features.ApiConnections.Commands.Queries;
using Core.Application.Features.ApiConnections.Commands.Queries.GetApiConnectionById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Core.Application.Features.ApiConnections.Commands.Create;
using Core.Application.Features.ApiConnections.Commands.Update;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Core.Application.Features.ApiConnections.Commands.Delete;

namespace Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ApiConnectionsController : ControllerBase
{
    private readonly ISender _mediator;

    public ApiConnectionsController(ISender mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Create([FromBody] CreateApiConnectionRequest request)
    {
        // Получаем ID пользователя из claims токена.
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out var userId))
        {
            return Unauthorized();
        }

        var command = new CreateApiConnectionCommand
        {
            UserId = userId,
            ConnectionName = request.ConnectionName,
            ExchangeName = request.ExchangeName,
            ApiKey = request.ApiKey,
            ApiSecret = request.ApiSecret
        };

        var connectionId = await _mediator.Send(command);

        // Этот ответ абсолютно корректен. Он возвращает статус 201 Created,
        // заголовок 'Location' со ссылкой на созданный ресурс (через GetById)
        // и тело ответа с ID.
        return CreatedAtAction(nameof(GetById), new { id = connectionId }, new { id = connectionId });
    }

    [HttpGet("{id:guid}", Name = "GetApiConnectionById")]
    [ProducesResponseType(typeof(ApiConnectionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdString, out var userId))
        {
            return Unauthorized();
        }

        var query = new GetApiConnectionByIdQuery
        {
            ConnectionId = id,
            UserId = userId
        };

        var result = await _mediator.Send(query);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateApiConnectionRequest request)
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out var userId))
        {
            return Unauthorized();
        }

        var command = new UpdateApiConnectionCommand
        {
            ConnectionId = id,
            UserId = userId,
            ConnectionName = request.ConnectionName,
            ApiKey = request.ApiKey,
            ApiSecret = request.ApiSecret
        };

        var success = await _mediator.Send(command);

        if (!success) return NotFound();

        return NoContent();

    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out var userId))
        {
            return Unauthorized();
        }

        var command = new DeleteApiConnectionCommand
        {
            ConnectionId = id,
            UserId = userId
        };

        var success = await _mediator.Send(command);

        if (!success) return NotFound();

        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ApiConnectionDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdString, out var userId))
        {
            return Unauthorized();
        }

        var query = new GetAllApiConnectionsQuery { UserId = userId };
        var result = await _mediator.Send(query);

        return Ok(result);
    }
}

