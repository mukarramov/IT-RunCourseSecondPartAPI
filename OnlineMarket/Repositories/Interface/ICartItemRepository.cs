using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface ICartItemRepository
{
    CartItem Add(CartItem cartItem);
    IEnumerable<CartItem> GetAll();
    CartItem Update(CartItem cartItem);
    CartItem Delete(Guid id);

    CartItem GetById(Guid id);

    public Product GetProductById(Guid id);
    public ShoppingCart GetShoppingCartById(Guid id);
}