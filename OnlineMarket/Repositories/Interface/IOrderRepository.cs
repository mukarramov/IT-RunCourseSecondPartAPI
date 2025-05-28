using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface IOrderRepository : IRepository<Order>
{
    public User GetUserById(Guid id);
    public IEnumerable<Order> GetOrders();
}