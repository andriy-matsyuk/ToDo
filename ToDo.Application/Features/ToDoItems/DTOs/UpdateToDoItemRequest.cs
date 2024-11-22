using ToDo.Domain.Enums;

namespace ToDo.Application.Features.ToDoItems.DTOs;

public class UpdateToDoItemRequest
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public Priority Priority { get; set; }
}