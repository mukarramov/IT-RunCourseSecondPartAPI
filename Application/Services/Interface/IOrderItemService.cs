using Application.Dtos.CreatedRequest;
using Application.Dtos.Response;

namespace Application.Services.Interface;

public interface IOrderItemService
{
    OrderItemResponse? Add(OrderItemCreate orderItemRequest);
    IEnumerable<OrderItemResponse> GetAll();
    IEnumerable<OrderItemResponse> GetOrderItemByPagination(int page, int pageSize);
    OrderItemResponse? Update(Guid id, OrderItemCreate orderItemRequest);
    OrderItemResponse? Delete(Guid id);

    OrderItemResponse? GetById(Guid id);
}