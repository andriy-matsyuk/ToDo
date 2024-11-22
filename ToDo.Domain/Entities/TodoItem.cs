using ToDo.Domain.Common;
using ToDo.Domain.Enums;

namespace ToDo.Domain.Entities;

public class TodoItem : BaseAuditableEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public Priority Priority { get; set; }
}