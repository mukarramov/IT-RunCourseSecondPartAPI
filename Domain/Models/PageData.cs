namespace Domain.Models;

public class PageData<T>
    where T : class
{
    public IEnumerable<T>? Items { get; set; }
    public int PageNumber { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
    public bool HasPreviousPage { get; set; }
    public bool HasNextPage { get; set; }
}