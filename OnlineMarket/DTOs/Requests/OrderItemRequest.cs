namespace IT_RunCourseSecondPartAPI.DTOs.Requests;

public class OrderItemRequest
{
    public Guid ProductId { get; set; }
    public Guid OrderId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}