using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface IOrderItemRepository
{
    OrderItem Create(OrderItem orderItem);
    IEnumerable<OrderItem> GetAll();
    OrderItem Update(OrderItem orderItem);
    bool Delete(int orderItemId);
}