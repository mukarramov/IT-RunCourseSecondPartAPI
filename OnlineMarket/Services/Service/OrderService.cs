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

        var order = mapper.Map<Order>(orderCreate);

        order.UserId = userById.Id;
        order.User = userById;

        orderRepository.Add(order);

        return mapper.Map<OrderResponse>(order);
    }

    public IEnumerable<OrderResponse> GetAll()
    {
        return orderRepository.GetAll().ToList()
            .Select(x => mapper.Map<OrderResponse>(x));
    }

    public OrderResponse Update(Guid id, OrderCreate orderCreate)
    {
        var order = orderRepository.GetById(id);

        var userById = orderRepository.GetUserById(orderCreate.UserId);

        order.TotalPrice = orderCreate.TotalPrice;
        order.UserId = userById.Id;
        order.User = userById;

        orderRepository.Update(id, order);

        return mapper.Map<OrderResponse>(order);
    }

    public OrderResponse Delete(Guid id)
    {
        return mapper.Map<OrderResponse>
            (orderRepository.Delete(id));
    }

    public OrderResponse GetById(Guid id)
    {
        return mapper.Map<OrderResponse>
            (orderRepository.GetById(id));
    }
}