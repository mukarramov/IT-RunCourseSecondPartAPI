using AutoMapper;
using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.DTOs.Response;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Services.Interface;

namespace IT_RunCourseSecondPartAPI.Services.Service;

public class OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper) : IOrderItemService
{
    public OrderItemResponse Add(OrderItemCreate orderItemRequest)
    {
        if (orderItemRequest is null)
        {
            throw new Exception();
        }

        var product = orderItemRepository.GetProductById(orderItemRequest.ProductId);
        var order = orderItemRepository.GetOrderById(orderItemRequest.OrderId);

        var orderItem = mapper.Map<OrderItem>(orderItemRequest);

        orderItem.ProductId = product.Id;
        orderItem.Product = product;
        orderItem.OrderId = order.Id;
        orderItem.Order = order;

        orderItemRepository.Add(orderItem);

        return mapper.Map<OrderItemResponse>(orderItem);
    }

    public IEnumerable<OrderItemResponse> GetAll()
    {
        return orderItemRepository.GetAll().ToList()
            .Select(x => mapper.Map<OrderItemResponse>(x));
    }

    public OrderItemResponse Update(Guid id, OrderItemCreate orderItemRequest)
    {
        var orderItem = orderItemRepository.GetById(id);

        var product = orderItemRepository.GetProductById(orderItemRequest.ProductId);
        var order = orderItemRepository.GetOrderById(orderItemRequest.OrderId);

        var map = mapper.Map<OrderItem>(orderItemRequest);

        map.ProductId = product.Id;
        map.Product = product;
        map.OrderId = order.Id;
        map.Order = order;

        orderItemRepository.Update(id, orderItem);

        return mapper.Map<OrderItemResponse>(map);
    }

    public OrderItemResponse Delete(Guid id)
    {
        return mapper.Map<OrderItemResponse>(orderItemRepository.Delete(id));
    }

    public OrderItemResponse GetById(Guid id)
    {
        return mapper.Map<OrderItemResponse>(orderItemRepository.GetById(id));
    }
}