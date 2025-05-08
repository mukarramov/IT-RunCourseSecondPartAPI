using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface IOrderRepository
{
    Order Create(Order order);
    IEnumerable<Order> GetAll();
    Order Update(Order order);
    bool Delete(int orderId);
}