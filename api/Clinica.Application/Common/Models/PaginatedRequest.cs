namespace Clinica.Application.Common.Models;

public class PaginatedRequest
{
    public int PageNumber { get; set; }

    public int PageSize { get; set; }

    public string? SortOrder { get; set; }

    public string? SortParameter { get; set; }

    public PaginatedRequest() { }

    public PaginatedRequest(int pageSize, int pageNumber, string? sortParameter, string? sortOrder)
    {
        this.PageNumber = pageNumber;
        this.PageSize = pageSize;
        this.SortOrder = sortOrder;
        this.SortParameter = sortParameter;
    }

}