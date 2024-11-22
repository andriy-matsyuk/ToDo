using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ToDo.Application.Common.Interfaces;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure.Data.Contexts;

public class InMemoryEFCoreContext : DbContext, IApplicationDbContext
{
    public InMemoryEFCoreContext(DbContextOptions<InMemoryEFCoreContext> options) : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}