using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.DTOs.Response;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Services.Interface;

namespace IT_RunCourseSecondPartAPI.Services.Service;

public class OrderService(IOrderRepository orderRepository) : IOrderService
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

        var orderResponse = new OrderResponse
        {
            Id = order.Id,
            TotalPrice = order.TotalPrice,
            OrderDate = order.OrderDate,
            UserId = order.UserId,
            User = order.User
        };

        return orderResponse;
    }

    public IQueryable<OrderResponse> GetAll()
    {
        var orders = orderRepository.GetAll();

        var orderResponses = orders.Select(order => new OrderResponse
        {
            Id = order.Id,
            TotalPrice = order.TotalPrice,
            OrderDate = order.OrderDate,
            UserId = order.UserId,
            User = order.User
        });

        return orderResponses;
    }

    public OrderResponse Update(Guid id, OrderCreate orderCreate)
    {
        var order = orderRepository.GetById(id);

        var userById = orderRepository.GetUserById(orderCreate.UserId);

        order.TotalPrice = orderCreate.TotalPrice;
        order.UserId = userById.Id;
        order.User = userById;

        var orderUpdate = orderRepository.Update(id, order);

        var orderResponse = new OrderResponse
        {
            Id = orderUpdate.Id,
            TotalPrice = orderUpdate.TotalPrice,
            OrderDate = orderUpdate.OrderDate,
            UserId = orderUpdate.UserId,
            User = orderUpdate.User
        };

        return orderResponse;
    }

    public OrderResponse Delete(Guid id)
    {
        var order = orderRepository.Delete(id);

        var orderResponse = new OrderResponse
        {
            Id = order.Id,
            TotalPrice = order.TotalPrice,
            OrderDate = order.OrderDate,
            UserId = order.UserId,
            User = order.User
        };

        return orderResponse;
    }

    public OrderResponse GetById(Guid id)
    {
        var order = orderRepository.GetById(id);

        var orderResponse = new OrderResponse
        {
            Id = order.Id,
            TotalPrice = order.TotalPrice,
            OrderDate = order.OrderDate,
            UserId = order.UserId,
            User = order.User
        };

        return orderResponse;
    }
}