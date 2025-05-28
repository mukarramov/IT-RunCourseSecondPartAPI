using AutoMapper;
using IT_RunCourseSecondPartAPI.DTOs.Requests;
using IT_RunCourseSecondPartAPI.DTOs.Response;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Services.Interface;

namespace IT_RunCourseSecondPartAPI.Services.Service;

public class OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper) : IOrderItemService
{
    public OrderItemResponse Add(OrderItemRequest orderItemRequest)
    {
        if (orderItemRequest is null)
        {
            throw new Exception();
        }

        var product = orderItemRepository.GetProductById(orderItemRequest.ProductId);
        var order = orderItemRepository.GetOrderById(orderItemRequest.OrderId);

        var orderItem = new OrderItem
        {
            ProductId = product.Id,
            Product = product,
            OrderId = order.Id,
            Order = order,
            Quantity = orderItemRequest.Quantity,
            Price = orderItemRequest.Price
        };

        orderItemRepository.Add(orderItem);

        return mapper.Map<OrderItemResponse>(orderItem);
    }

    public IEnumerable<OrderItemResponse> GetAll()
    {
        var orderItems = orderItemRepository.GetOrderItems();

        return mapper.Map<IEnumerable<OrderItemResponse>>(orderItems);
    }

    public OrderItemResponse Update(Guid id, OrderItemRequest orderItemRequest)
    {
        var orderItem = orderItemRepository.GetById(id);

        var product = orderItemRepository.GetProductById(orderItemRequest.ProductId);
        var order = orderItemRepository.GetOrderById(orderItemRequest.OrderId);

        orderItem.ProductId = product.Id;
        orderItem.Product = product;
        orderItem.OrderId = order.Id;
        orderItem.Order = order;

        orderItemRepository.Update(id, orderItem);

        return mapper.Map<OrderItemResponse>(orderItem);
    }

    public OrderItemResponse Delete(Guid id)
    {
        var orderItem = orderItemRepository.Delete(id);

        return mapper.Map<OrderItemResponse>(orderItem);
    }

    public OrderItemResponse GetById(Guid id)
    {
        var orderItem = orderItemRepository.GetById(id);

        return mapper.Map<OrderItemResponse>(orderItem);
    }
}