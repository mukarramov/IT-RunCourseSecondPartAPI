using Application.Dtos.CreatedRequest;
using Application.Dtos.Response;

namespace Application.Services.Interface;

public interface IShoppingCartService
{
    ShoppingCartResponse? Add(ShoppingCartCreate shoppingCartCreate);
    IEnumerable<ShoppingCartResponse> GetAll();
    ShoppingCartResponse? Update(Guid id, ShoppingCartCreate shoppingCartCreate);
    ShoppingCartResponse? Delete(Guid id);
    ShoppingCartResponse? GetById(Guid id);
}