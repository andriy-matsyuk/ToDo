using FluentValidation;

namespace ToDo.Application.Features.ToDoItems.Commands;

public class UpdateToDoItemCommandValidator : AbstractValidator<UpdateToDoItemCommand>
{
    public UpdateToDoItemCommandValidator()
    {
        RuleFor(x => x.Request.Title)
            .MaximumLength(255);

        RuleFor(x => x.Request.Description)
            .MaximumLength(1000);

        RuleFor(x => x.Request.Priority)
            .IsInEnum();
    }
}
