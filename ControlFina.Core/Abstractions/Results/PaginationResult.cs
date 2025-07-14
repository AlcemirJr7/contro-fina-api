namespace ControlFina.Core.Abstractions.Results;

public class PaginationResult<T>
{
    public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    public int CurrentPage { get; set; } = 1;
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
    public int PageSize { get; set; } = 10;
    public PaginationResult() { }
    public PaginationResult(IEnumerable<T> items, int currentPage, int totalPages, int totalItems, int pageSize)
    {
        Items = items;
        CurrentPage = currentPage;
        TotalPages = totalPages;
        TotalItems = totalItems;
        PageSize = pageSize;
    }
}
