namespace IT_RunCourseSecondPartAPI.Models;

public class OrderItem : IEntity
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public Guid OrderId { get; set; }
    public Order? Order { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public bool IsDeleted { get; set; }
}