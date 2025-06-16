using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface IShoppingCartRepository
{
    ShoppingCart Add(ShoppingCart shoppingCart);
    IEnumerable<ShoppingCart> GetAll();
    ShoppingCart? Update(ShoppingCart shoppingCart);
    ShoppingCart? Delete(Guid id);

    ShoppingCart? GetById(Guid id);
}