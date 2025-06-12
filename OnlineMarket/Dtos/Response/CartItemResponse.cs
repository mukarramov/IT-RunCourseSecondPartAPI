using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.DTOs.Response;

public class CartItemResponse
{
    public Guid Id { get; set; }
    public Guid ShoppingCartId { get; set; }
    public ShoppingCart? ShoppingCart { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
}