using ToDo.Application.Common.Specifications;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.ToDoItems.Specifications;

public class TodoItemsByTitleSpecification : BaseSpecification<TodoItem>
{
    public TodoItemsByTitleSpecification(string searchTerm)
        : base(x => string.IsNullOrEmpty(searchTerm) ||
                   x.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
    {
    }
}
