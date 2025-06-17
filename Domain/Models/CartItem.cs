namespace Domain.Models;

public class CartItem : IEntity
{
    public Guid Id { get; set; }
    public Guid ShoppingCartId { get; set; }
    public ShoppingCart? ShoppingCart { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public bool IsDeleted { get; set; }
}