using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface ICartItemRepository
{
    CartItem Add(CartItem cartItem);
    IEnumerable<CartItem> GetAll();
    CartItem? Update(CartItem cartItem);
    CartItem? Delete(Guid id);

    CartItem? GetById(Guid id);

    Product? GetProductById(Guid id);
    ShoppingCart? GetShoppingCartById(Guid id);
}