using System.Linq.Expressions;
using ToDo.Application.Common.Interfaces;

namespace ToDo.Application.Common.Specifications;

public abstract class BaseSpecification<T> : ISpecification<T>
{
    public virtual Expression<Func<T, bool>> Criteria { get; private set; } = null!;
    public virtual List<Expression<Func<T, object>>> Includes { get; } = [];
    public virtual Expression<Func<T, object>> OrderBy { get; private set; } = null!;
    public virtual Expression<Func<T, object>> OrderByDescending { get; private set; } = null!;

    protected BaseSpecification()
    {
    }

    protected BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    protected virtual void AddOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }

    protected virtual void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
    {
        OrderByDescending = orderByDescExpression;
    }
}
