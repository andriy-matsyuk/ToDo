using ToDo.Domain.Entities;
using ToDo.Domain.Enums;

namespace ToDo.Application.Features.ToDoItems.DTOs;

public class ToDoItemDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public Priority Priority { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    public static ToDoItemDTO FromToDoItem(TodoItem entity)
    {
        return new ToDoItemDTO
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            Priority = entity.Priority,
            IsCompleted = entity.IsCompleted,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt
        };
    }
}