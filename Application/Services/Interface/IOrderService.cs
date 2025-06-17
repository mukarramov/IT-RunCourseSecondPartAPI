using Application.Dtos.CreatedRequest;
using Application.Dtos.Response;

namespace Application.Services.Interface;

public interface IOrderService
{
    OrderResponse? Add(OrderCreate orderCreate);
    IEnumerable<OrderResponse> GetAll();
    OrderResponse? Update(Guid id, OrderCreate orderCreate);
    OrderResponse? Delete(Guid id);

    OrderResponse? GetById(Guid id);
}