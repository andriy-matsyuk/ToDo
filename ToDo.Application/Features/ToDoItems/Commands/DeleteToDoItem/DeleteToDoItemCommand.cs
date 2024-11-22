using MediatR;

namespace ToDo.Application.Features.ToDoItems.Commands;

public record DeleteToDoItemCommand : IRequest
{
    public Guid Id { get; init; }
}