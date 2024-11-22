using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure.Data.Configurations;

public class ToDoItemConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title)
            .HasMaxLength(255);

        builder.Property(t => t.Description)
            .HasMaxLength(1000);

        builder.Property(t => t.IsCompleted)
            .IsRequired();

        builder.Property(t => t.Priority)
            .IsRequired()
            .HasConversion<int>();

        builder.HasIndex(t => t.Priority);
        builder.HasIndex(t => t.UpdatedAt);
        builder.HasIndex(t => t.Title);
    }
}