using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Repositories.Interface;

public interface IOrderItemRepository
{
    OrderItem Add(OrderItem orderItem);
    IQueryable<OrderItem> GetAll();
    OrderItem Update(Guid id, OrderItem orderItem);
    OrderItem Delete(Guid id);

    OrderItem GetById(Guid id);

    public Product GetProductById(Guid id);
    public Order GetOrderById(Guid id);
}