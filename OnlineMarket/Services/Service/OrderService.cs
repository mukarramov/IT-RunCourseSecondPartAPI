using AutoMapper;
using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.DTOs.Response;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Services.Interface;

namespace IT_RunCourseSecondPartAPI.Services.Service;

public class OrderService(IOrderRepository orderRepository, IMapper mapper) : IOrderService
{
    public OrderResponse Add(OrderCreate orderCreate)
    {
        if (orderCreate is null)
        {
            throw new Exception();
        }

        var userById = orderRepository.GetUserById(orderCreate.UserId);

        var order = new Order
        {
            UserId = userById.Id,
            User = userById,
            TotalPrice = orderCreate.TotalPrice
        };

        orderRepository.Add(order);

        return mapper.Map<OrderResponse>(order);
    }

    public IEnumerable<OrderResponse> GetAll()
    {
        var orders = orderRepository.GetOrders();

        return mapper.Map<IEnumerable<OrderResponse>>(orders);
    }

    public OrderResponse Update(Guid id, OrderCreate orderCreate)
    {
        var order = orderRepository.GetById(id);

        var userById = orderRepository.GetUserById(orderCreate.UserId);

        order.UserId = userById.Id;
        order.User = userById;
        order.TotalPrice = orderCreate.TotalPrice;

        var update = orderRepository.Update(id, order);

        return mapper.Map<OrderResponse>(update);
    }

    public OrderResponse Delete(Guid id)
    {
        var order = orderRepository.Delete(id);

        return mapper.Map<OrderResponse>(order);
    }

    public OrderResponse GetById(Guid id)
    {
        var order = orderRepository.GetById(id);

        return mapper.Map<OrderResponse>(order);
    }
}