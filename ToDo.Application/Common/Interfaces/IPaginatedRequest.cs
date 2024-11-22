namespace ToDo.Application.Common.Interfaces;

public interface IPaginatedRequest
{
    int PageNumber { get; }
    int PageSize { get; }
}