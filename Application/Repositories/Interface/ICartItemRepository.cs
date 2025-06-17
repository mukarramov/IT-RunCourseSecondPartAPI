using Domain.Models;

namespace Application.Repositories.Interface;

public interface ICartItemRepository
{
    CartItem Add(CartItem cartItem);
    IEnumerable<CartItem> GetAll();
    CartItem? Update(CartItem cartItem);
    CartItem? Delete(Guid id);

    CartItem? GetById(Guid id);
}