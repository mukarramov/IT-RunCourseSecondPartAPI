using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.DTOs.Response;

public class ProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
}