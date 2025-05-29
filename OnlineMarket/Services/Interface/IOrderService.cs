using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.DTOs.Response;

namespace IT_RunCourseSecondPartAPI.Services.Interface;

public interface IOrderService
{
    OrderResponse Add(OrderCreate orderCreate);
    IEnumerable<OrderResponse> GetAll();
    OrderResponse Update(Guid id, OrderCreate orderCreate);
    OrderResponse Delete(Guid id);

    OrderResponse GetById(Guid id);
}