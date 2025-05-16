using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Repositories.Repository;
using IT_RunCourseSecondPartAPI.Services.Interface;

namespace IT_RunCourseSecondPartAPI.Services.Service;

public class OrderItemService(IRepository<OrderItem> orderItemRepository):IService<OrderItem>
{
    public OrderItem Add(OrderItem entity)
    {
        orderItemRepository.Create(entity);

        return entity;
    }

    public IEnumerable<OrderItem> GetAll()
    {
        return OrderItemRepository.OrderItems;
    }

    public bool Update(Guid id, OrderItem entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public OrderItem GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}