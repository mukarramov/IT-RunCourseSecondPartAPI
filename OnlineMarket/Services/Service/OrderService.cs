using AutoMapper;
using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.DTOs.Response;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Services.Interface;

namespace IT_RunCourseSecondPartAPI.Services.Service;

public class OrderService(IOrderRepository orderRepository, IMapper mapper, ILogger<Order> logger) : IOrderService
{
    public OrderResponse? Add(OrderCreate orderCreate)
    {
        if (orderCreate is null)
        {
            throw new Exception();
        }

        var userById = orderRepository.GetUserById(orderCreate.UserId);
        if (userById is null)
        {
            return null;
        }

        var order = mapper.Map<Order>(orderCreate);

        order.UserId = userById.Id;
        order.User = userById;

        orderRepository.Add(order);

        return mapper.Map<OrderResponse>(order);
    }

    public IEnumerable<OrderResponse> GetAll()
    {
        return orderRepository.GetAll()
            .Select(mapper.Map<OrderResponse>);
    }

    public OrderResponse? Update(Guid id, OrderCreate orderCreate)
    {
        var order = orderRepository.GetById(id);
        if (order is null)
        {
            return null;
        }

        var userById = orderRepository.GetUserById(orderCreate.UserId);
        if (userById is null)
        {
            return null;
        }

        order.Id = id;
        order.TotalPrice = orderCreate.TotalPrice;
        order.UserId = userById.Id;
        order.User = userById;

        orderRepository.Update(order);

        logger.LogInformation("update {order} successfully passed", order);

        return mapper.Map<OrderResponse>(order);
    }

    public OrderResponse? Delete(Guid id)
    {
        var order = orderRepository.Delete(id);

        return order is null ? null : mapper.Map<OrderResponse>(order);
    }

    public OrderResponse? GetById(Guid id)
    {
        var order = orderRepository.GetById(id);

        return order is null ? null : mapper.Map<OrderResponse>(order);
    }
}