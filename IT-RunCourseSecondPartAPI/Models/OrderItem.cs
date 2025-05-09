namespace IT_RunCourseSecondPartAPI.Models;

public class OrderItem:IEntity
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = new();
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = new();
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}