namespace IT_RunCourseSecondPartAPI.Models;

public class OrderItem
{
    public int Id { get; set; }
    public int IdProduct { get; set; }
    public Product Product { get; set; } = new();
    public int OrderId { get; set; }
    public Order Order { get; set; } = new();
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}