using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface IOrderItemRepository
{
    OrderItem Add(OrderItem orderItem);
    IEnumerable<OrderItem> GetAll();
    OrderItem? Update(OrderItem orderItem);
    OrderItem? Delete(Guid id);

    OrderItem? GetById(Guid id);

    Product? GetProductById(Guid id);
    Order? GetOrderById(Guid id);
}