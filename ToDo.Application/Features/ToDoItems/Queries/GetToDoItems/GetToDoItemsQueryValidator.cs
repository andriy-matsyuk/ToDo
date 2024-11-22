using FluentValidation;
using ToDo.Application.Common.Validators;

namespace ToDo.Application.Features.ToDoItems.Queries;

public class GetToDoItemsQueryValidator : PaginationValidator<GetToDoItemsQuery>
{
    public GetToDoItemsQueryValidator() 
    {
        RuleFor(x => x.SearchTerm)
            .MaximumLength(100);

        RuleFor(x => x.Priority)
            .IsInEnum();
    }
}
