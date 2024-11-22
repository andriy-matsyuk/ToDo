using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Common.Models;
using ToDo.Application.Features.ToDoItems.Commands.AddToDoItem;
using ToDo.Application.Features.ToDoItems.Commands;
using ToDo.Application.Features.ToDoItems.DTOs;
using ToDo.Application.Features.ToDoItems.Queries;

namespace ToDo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToDosController : ControllerBase
{
    private readonly IMediator _mediator;

    public ToDosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromBody] AddToDoItemCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(new { id });
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteToDoItemCommand { Id = id });
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateToDoItemRequest request)
    {
        await _mediator.Send(new UpdateToDoItemCommand
        {
            ToDoItemId = id,
            Request = request
        });
        return NoContent();
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ToDoItemDTO), StatusCodes.Status200OK)]
    public async Task<ActionResult<ToDoItemDTO>> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetToDoItemQuery { Id = id });
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(PaginatedList<ToDoItemDTO>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PaginatedList<ToDoItemDTO>>> GetAll(
        [FromQuery] GetToDoItemsQuery query
        )
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}
