using FluentValidation;

namespace ToDo.Application.Features.ToDoItems.Commands.AddToDoItem;

public class AddToDoItemCommandValidator : AbstractValidator<AddToDoItemCommand>
{
    public AddToDoItemCommandValidator()
    {
        RuleFor(x => x.Title)
            .MaximumLength(255);

        RuleFor(x => x.Description)
            .MaximumLength(1000);

        RuleFor(x => x.Priority)
            .IsInEnum();
    }
}