using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.DTOs.Response;

public class OrderItemResponse
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public Guid OrderId { get; set; }
    public Order? Order { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}