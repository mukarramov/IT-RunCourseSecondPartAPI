using Domain.Models;

namespace Application.Repositories.Interface;

public interface IOrderItemRepository
{
    OrderItem Add(OrderItem orderItem);
    IEnumerable<OrderItem> GetAll();
    IEnumerable<OrderItem> GetOrderItemByPagination(int page, int pageSize);
    OrderItem? Update(OrderItem orderItem);
    OrderItem? Delete(Guid id);

    OrderItem? GetById(Guid id);
}