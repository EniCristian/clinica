namespace Clinica.Application.Common.Models;

public class PaginatedResponse<T>
{
    public required IEnumerable<T> Items { get; set; }

    public required Pagination? Pagination { get; set; }

    public required Sort? Sort { get; set; }
}
public class Pagination
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
}

public class Sort
{
    public required string Order { get; set; }
    public required string Parameter { get; set; }
}