namespace IT_RunCourseSecondPartAPI.Models;

public class ShoppingCart : IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public List<CartItem>? CartItems { get; set; }
    public List<Product>? Products { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public bool IsDeleted { get; set; }
}