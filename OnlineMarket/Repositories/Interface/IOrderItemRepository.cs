using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface IOrderItemRepository
{
    OrderItem Add(OrderItem orderItem);
    IEnumerable<OrderItem> GetAll();
    OrderItem Update(Guid id, OrderItem orderItem);
    OrderItem Delete(Guid id);

    OrderItem GetById(Guid id);

    public Product GetProductById(Guid id);
    public Order GetOrderById(Guid id);
    public IEnumerable<OrderItem> GetOrderItems();
}