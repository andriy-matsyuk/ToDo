using MediatR;
using ToDo.Domain.Enums;

namespace ToDo.Application.Features.ToDoItems.Commands.AddToDoItem;

public record AddToDoItemCommand : IRequest<Guid>
{
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public Priority Priority { get; init; }
}