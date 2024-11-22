using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Common.Exceptions;
using ToDo.Application.Common.Interfaces;
using ToDo.Application.Features.ToDoItems.DTOs;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.ToDoItems.Commands;

public class UpdateToDoItemCommandHandler : IRequestHandler<UpdateToDoItemCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateToDoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Handle(UpdateToDoItemCommand request, CancellationToken cancellationToken)
    {
        var existingTodoItem = await _context.TodoItems
           .FirstOrDefaultAsync(t => t.Id == request.ToDoItemId, cancellationToken)
               ?? throw new NotFoundException(nameof(TodoItem), request.ToDoItemId);

        UpdateToDoItemProperties(existingTodoItem, request.Request);

        await _context.SaveChangesAsync(cancellationToken);
    }

    private void UpdateToDoItemProperties(TodoItem todoItem, UpdateToDoItemRequest updateRequest)
    {
        todoItem.Title = updateRequest.Title;
        todoItem.Description = updateRequest.Description;
        todoItem.Priority = updateRequest.Priority;
        todoItem.IsCompleted = updateRequest.IsCompleted;
    }
}