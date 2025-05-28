using IT_RunCourseSecondPartAPI.DTOs.Requests;
using IT_RunCourseSecondPartAPI.DTOs.Response;

namespace IT_RunCourseSecondPartAPI.Services.Interface;

public interface IOrderItemService
{
    OrderItemResponse Add(OrderItemRequest orderItemRequest);
    IEnumerable<OrderItemResponse> GetAll();
    OrderItemResponse Update(Guid id, OrderItemRequest orderItemRequest);
    OrderItemResponse Delete(Guid id);

    OrderItemResponse GetById(Guid id);
}