namespace ControlFina.Core.Models;

public sealed class Pagination
{
    public int CurrentPage { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public int? TotalItens { get; set; } = 0;
}
