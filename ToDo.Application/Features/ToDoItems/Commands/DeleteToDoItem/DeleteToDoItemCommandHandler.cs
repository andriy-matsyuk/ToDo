using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Common.Exceptions;
using ToDo.Application.Common.Interfaces;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.ToDoItems.Commands;

public class DeleteToDoItemCommandHandler : IRequestHandler<DeleteToDoItemCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteToDoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Handle(DeleteToDoItemCommand request, CancellationToken cancellationToken)
    {
        var existingTodoItem = await _context.TodoItems
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(TodoItem), request.Id);

        _context.TodoItems.Remove(existingTodoItem);
        await _context.SaveChangesAsync(cancellationToken);
    }
}