using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.DTOs;

public record OrderItemDto
{
    public Product Product { get; set; } = new();
    public Order Order { get; set; } = new();
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}