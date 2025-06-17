using Domain.Models;

namespace Application.Dtos.Response;

public class ShoppingCartResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public List<CartItem>? CartItems { get; set; }
    public List<Product>? Products { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
}