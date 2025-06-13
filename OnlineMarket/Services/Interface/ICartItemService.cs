using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.DTOs.Response;

namespace IT_RunCourseSecondPartAPI.Services.Interface;

public interface ICartItemService
{
    CartItemResponse Add(CartItemCreate cartItemCreate);
    IEnumerable<CartItemResponse> GetAll();
    CartItemResponse Update(Guid id, CartItemCreate cartItemCreate);
    CartItemResponse Delete(Guid id);
    CartItemResponse GetById(Guid id);
}