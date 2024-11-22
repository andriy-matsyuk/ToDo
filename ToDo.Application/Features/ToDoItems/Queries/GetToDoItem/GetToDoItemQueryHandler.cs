using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Common.Exceptions;
using ToDo.Application.Common.Interfaces;
using ToDo.Application.Features.ToDoItems.DTOs;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.ToDoItems.Queries;

public class GetToDoItemQueryHandler : IRequestHandler<GetToDoItemQuery, ToDoItemDTO>
{
    private readonly IApplicationDbContext _context;

    public GetToDoItemQueryHandler(IApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<ToDoItemDTO> Handle(GetToDoItemQuery request, CancellationToken cancellationToken)
    {
        var todoItem = await _context.TodoItems
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(TodoItem), request.Id);

        return ToDoItemDTO.FromToDoItem(todoItem);
    }
}
