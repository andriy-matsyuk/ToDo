using ToDo.Application.Common.Specifications;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.ToDoItems.Specifications;

public class TodoItemsOrderedByPrioritySpecification : BaseSpecification<TodoItem>
{
    public TodoItemsOrderedByPrioritySpecification()
    {
        AddOrderByDescending(x => x.Priority);
        AddOrderBy(x => x.UpdatedAt);
    }
}
