using ToDo.Application.Common.Specifications;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.ToDoItems.Specifications;

public class TodoItemsOrderedByUpdateDateSpecification : BaseSpecification<TodoItem>
{
    public TodoItemsOrderedByUpdateDateSpecification()
    {
        AddOrderByDescending(x => x.UpdatedAt);
    }
}
