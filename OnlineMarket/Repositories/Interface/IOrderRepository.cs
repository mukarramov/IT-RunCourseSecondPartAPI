using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface IOrderRepository
{
    Order Add(Order order);
    IEnumerable<Order> GetAll();
    Order Update(Guid id, Order order);
    Order Delete(Guid id);

    Order GetById(Guid id);

    public User GetUserById(Guid id);
    public IEnumerable<Order> GetOrders();
}