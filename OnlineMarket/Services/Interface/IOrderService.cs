using IT_RunCourseSecondPartAPI.DTOs.Requests;
using IT_RunCourseSecondPartAPI.DTOs.Response;

namespace IT_RunCourseSecondPartAPI.Services.Interface;

public interface IOrderService
{
    OrderResponse Add(OrderRequest orderRequest);
    IEnumerable<OrderResponse> GetAll();
    OrderResponse Update(Guid id, OrderRequest orderRequest);
    OrderResponse Delete(Guid id);

    OrderResponse GetById(Guid id);
}