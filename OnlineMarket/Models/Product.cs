namespace IT_RunCourseSecondPartAPI.Models;

public class Product : IEntity
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
    public Guid ShoppingCartId { get; set; }
    public ShoppingCart? ShoppingCart { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public bool IsDeleted { get; set; }
    public List<CartItem>? CartItems { get; set; }
    public List<OrderItem>? OrderItems { get; set; }
}