using AutoMapper;
using IT_RunCourseSecondPartAPI.DTOs.Requests;
using IT_RunCourseSecondPartAPI.DTOs.Response;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Services.Interface;

namespace IT_RunCourseSecondPartAPI.Services.Service;

public class OrderService(IOrderRepository orderRepository, IMapper mapper) : IOrderService
{
    public OrderResponse Add(OrderRequest orderRequest)
    {
        if (orderRequest is null)
        {
            throw new Exception();
        }

        var userById = orderRepository.GetUserById(orderRequest.UserId);

        var order = new Order
        {
            UserId = userById.Id,
            User = userById,
            TotalPrice = orderRequest.TotalPrice
        };

        orderRepository.Add(order);

        return mapper.Map<OrderResponse>(order);
    }

    public IEnumerable<OrderResponse> GetAll()
    {
        var orders = orderRepository.GetOrders();

        return mapper.Map<IEnumerable<OrderResponse>>(orders);
    }

    public OrderResponse Update(Guid id, OrderRequest orderRequest)
    {
        var order = orderRepository.GetById(id);

        var userById = orderRepository.GetUserById(orderRequest.UserId);

        order.UserId = userById.Id;
        order.User = userById;
        order.TotalPrice = orderRequest.TotalPrice;

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