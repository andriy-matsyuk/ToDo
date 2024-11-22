using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Common.Interfaces;
using ToDo.Application.Common.Models;
using ToDo.Application.Features.ToDoItems.DTOs;
using ToDo.Application.Features.ToDoItems.Specifications;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.ToDoItems.Queries;

public class GetToDoItemsQueryHandler : IRequestHandler<GetToDoItemsQuery, PaginatedList<ToDoItemDTO>>
{
    private readonly IApplicationDbContext _context;
    private readonly ISpecificationEvaluator<TodoItem> _specificationEvaluator;

    public GetToDoItemsQueryHandler(
        IApplicationDbContext context,
        ISpecificationEvaluator<TodoItem> specificationEvaluator)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _specificationEvaluator = specificationEvaluator ?? throw new ArgumentNullException(nameof(specificationEvaluator));
    }

    public async Task<PaginatedList<ToDoItemDTO>> Handle(GetToDoItemsQuery request, CancellationToken cancellationToken)
    {
        var specification = new TodoItemsCompositeSpecification(request);

        var query = _specificationEvaluator
            .GetQuery(_context.TodoItems.AsNoTracking(), specification);

        return await PaginatedList<ToDoItemDTO>.CreateAsync(query, request.PageNumber, request.PageSize, ToDoItemDTO.FromToDoItem);
    }
}