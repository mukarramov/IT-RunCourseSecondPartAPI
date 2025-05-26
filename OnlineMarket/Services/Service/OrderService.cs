using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Repositories.Repository;
using IT_RunCourseSecondPartAPI.Services.Interface;

namespace IT_RunCourseSecondPartAPI.Services.Service;

public class OrderService(IRepository<Order> orderRepository) : IService<Order>
{
    public Order Add(Order entity)
    {
        orderRepository.Create(entity);

        return entity;
    }

    public IEnumerable<Order> GetAll()
    {
        return OrderRepository.Orders;
    }

    public bool Update(Guid id, Order entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Order GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}