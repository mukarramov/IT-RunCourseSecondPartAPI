using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface ICartItemRepository
{
    CartItem Add(CartItem cartItem);
    IQueryable<CartItem> GetAll();
    CartItem Update(Guid id, CartItem cartItem);
    CartItem Delete(Guid id);

    CartItem GetById(Guid id);

    public Product GetProductById(Guid id);
    public ShoppingCart GetShoppingCartById(Guid id);
}