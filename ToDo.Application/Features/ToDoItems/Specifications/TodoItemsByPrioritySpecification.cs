using ToDo.Application.Common.Specifications;
using ToDo.Domain.Entities;
using ToDo.Domain.Enums;

namespace ToDo.Application.Features.ToDoItems.Specifications;

public class TodoItemsByPrioritySpecification : BaseSpecification<TodoItem>
{
    public TodoItemsByPrioritySpecification(Priority? priority)
        : base(x => !priority.HasValue || x.Priority == priority.Value)
    {
    }
}
