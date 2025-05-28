using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface IOrderItemRepository : IRepository<OrderItem>
{
    public Product GetProductById(Guid id);
    public Order GetOrderById(Guid id);
    public IEnumerable<OrderItem> GetOrderItems();
}