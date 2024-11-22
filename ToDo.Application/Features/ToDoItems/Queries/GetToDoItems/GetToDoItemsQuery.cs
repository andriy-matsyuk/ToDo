using MediatR;
using ToDo.Application.Common.Interfaces;
using ToDo.Application.Common.Models;
using ToDo.Application.Features.ToDoItems.DTOs;
using ToDo.Domain.Enums;

namespace ToDo.Application.Features.ToDoItems.Queries;

public record GetToDoItemsQuery : IRequest<PaginatedList<ToDoItemDTO>>, IPaginatedRequest
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 25;
    public string? SearchTerm { get; init; }
    public Priority? Priority { get; init; }
    public string? OrderBy { get; init; }
}