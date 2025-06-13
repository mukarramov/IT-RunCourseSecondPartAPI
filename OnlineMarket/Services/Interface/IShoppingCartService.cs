using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.DTOs.Response;
using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Services.Interface;

public interface IShoppingCartService
{
    ShoppingCartResponse Add(ShoppingCartCreate shoppingCartCreate);
    IEnumerable<ShoppingCartResponse> GetAll();
    ShoppingCartResponse Update(Guid id, ShoppingCartCreate shoppingCartCreate);
    ShoppingCartResponse Delete(Guid id);
    ShoppingCartResponse GetById(Guid id);
}