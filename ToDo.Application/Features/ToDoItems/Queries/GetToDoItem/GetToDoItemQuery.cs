using MediatR;
using ToDo.Application.Features.ToDoItems.DTOs;

namespace ToDo.Application.Features.ToDoItems.Queries;

public record GetToDoItemQuery : IRequest<ToDoItemDTO>
{
    public Guid Id { get; init; }
}