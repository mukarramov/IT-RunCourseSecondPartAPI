using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.DTOs.Response;

namespace IT_RunCourseSecondPartAPI.Services.Interface;

public interface IOrderItemService
{
    OrderItemResponse? Add(OrderItemCreate orderItemRequest);
    IEnumerable<OrderItemResponse> GetAll();
    OrderItemResponse? Update(Guid id, OrderItemCreate orderItemRequest);
    OrderItemResponse? Delete(Guid id);

    OrderItemResponse? GetById(Guid id);
}