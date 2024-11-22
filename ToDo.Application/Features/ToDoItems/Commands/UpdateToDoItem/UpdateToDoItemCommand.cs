using MediatR;
using ToDo.Application.Features.ToDoItems.DTOs;

namespace ToDo.Application.Features.ToDoItems.Commands;

public record UpdateToDoItemCommand : IRequest
{
    public Guid ToDoItemId { get; init; }
    public UpdateToDoItemRequest Request { get; init; } = null!;
}