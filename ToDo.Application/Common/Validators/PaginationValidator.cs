using FluentValidation;
using ToDo.Application.Common.Interfaces;

namespace ToDo.Application.Common.Validators;

public abstract class PaginationValidator<T> : AbstractValidator<T> where T : IPaginatedRequest
{
    protected PaginationValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThan(0);

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 1000);
    }
}
