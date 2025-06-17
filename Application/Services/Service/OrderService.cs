using Application.Dtos.CreatedRequest;
using Application.Dtos.Response;
using Application.Repositories.Interface;
using Application.Services.Interface;
using AutoMapper;
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace Application.Services.Service;

public class OrderService(
    IOrderRepository orderRepository,
    IUserRepository userRepository,
    ICartItemRepository cartItemRepository,
    IMapper mapper,
    ILogger<Order> logger) : IOrderService
{
    public OrderResponse? Add(OrderCreate orderCreate)
    {
        if (orderCreate is null)
        {
            throw new Exception();
        }

        var userById = userRepository.GetById(orderCreate.UserId);
        if (userById is null)
        {
            return null;
        }

        var order = mapper.Map<Order>(orderCreate);

        order.UserId = userById.Id;
        order.User = userById;

        var cartItems = cartItemRepository.GetAll();

        var sum = cartItems.Sum(x => x.TotalPrice);

        order.TotalPrice = sum;

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
        var userById = userRepository.GetById(orderCreate.UserId);

        if (order is null || userById is null)
        {
            return null;
        }

        order.Id = id;
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