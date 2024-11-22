using MediatR;
using ToDo.Application.Common.Interfaces;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.ToDoItems.Commands.AddToDoItem;

public class AddToDoItemCommandHandler : IRequestHandler<AddToDoItemCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public AddToDoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Guid> Handle(AddToDoItemCommand request, CancellationToken cancellationToken)
    {
        var todoItem = new TodoItem
        {
            Title = request.Title,
            Description = request.Description,
            Priority = request.Priority,
            IsCompleted = false
        };
        _context.TodoItems.Add(todoItem);

        await _context.SaveChangesAsync(cancellationToken);

        return todoItem.Id;
    }
}
