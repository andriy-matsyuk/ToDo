using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;

namespace ToDo.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoItem> TodoItems { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
