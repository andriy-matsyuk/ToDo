using System.Linq.Expressions;
using ToDo.Application.Common.Interfaces;
using ToDo.Application.Common.Specifications;
using ToDo.Application.Features.ToDoItems.Queries;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.ToDoItems.Specifications;

public class TodoItemsCompositeSpecification : BaseSpecification<TodoItem>
{
    private readonly List<ISpecification<TodoItem>> _specifications = [];

    public TodoItemsCompositeSpecification(GetToDoItemsQuery parameters)
    {
        if (!string.IsNullOrEmpty(parameters.SearchTerm))
        {
            _specifications.Add(new TodoItemsByTitleSpecification(parameters.SearchTerm));
        }

        if (parameters.Priority.HasValue)
        {
            _specifications.Add(new TodoItemsByPrioritySpecification(parameters.Priority));
        }

        if (parameters.OrderBy?.ToLower() == "priority")
        {
            _specifications.Add(new TodoItemsOrderedByPrioritySpecification());
        }
        else
        {
            _specifications.Add(new TodoItemsOrderedByUpdateDateSpecification());
        }
    }

    public override Expression<Func<TodoItem, bool>> Criteria
    {
        get
        {
            Expression<Func<TodoItem, bool>> criteria = x => true;

            foreach (var spec in _specifications.Where(s => s.Criteria != null))
            {
                var previousCriteria = criteria;
                var specCriteria = spec.Criteria;

                var parameter = Expression.Parameter(typeof(TodoItem), "x");
                var combined = Expression.AndAlso(
                    Expression.Invoke(previousCriteria, parameter),
                    Expression.Invoke(specCriteria, parameter)
                );
                criteria = Expression.Lambda<Func<TodoItem, bool>>(combined, parameter);
            }

            return criteria;
        }
    }

    public override Expression<Func<TodoItem, object>> OrderBy =>
        _specifications.FirstOrDefault(x => x.OrderBy != null)?.OrderBy;

    public override Expression<Func<TodoItem, object>> OrderByDescending =>
        _specifications.FirstOrDefault(x => x.OrderByDescending != null)?.OrderByDescending;
}