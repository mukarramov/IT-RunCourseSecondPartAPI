using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface IOrderRepository
{
    Order Add(Order order);
    IEnumerable<Order> GetAll();
    Order? Update(Order order);
    Order? Delete(Guid id);

    Order? GetById(Guid id);
}