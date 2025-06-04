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

        var orderItemResponse = new OrderItemResponse
        {
            Id = orderItem.Id,
            Price = orderItem.Price,
            Quantity = orderItem.Quantity,
            ProductId = orderItem.ProductId,
            Product = orderItem.Product,
            OrderId = orderItem.OrderId,
            Order = orderItem.Order
        };

        return orderItemResponse;
    }

    public IEnumerable<OrderItemResponse> GetAll()
    {
        var orderItems = orderItemRepository.GetAll();

        var orderItemResponses = orderItems.Select(orderItem => new OrderItemResponse
        {
            Id = orderItem.Id,
            Price = orderItem.Price,
            Quantity = orderItem.Quantity,
            ProductId = orderItem.ProductId,
            Product = orderItem.Product,
            OrderId = orderItem.OrderId,
            Order = orderItem.Order
        });

        return orderItemResponses;
    }

    public OrderItemResponse Update(Guid id, OrderItemCreate orderItemRequest)
    {
        var orderItem = orderItemRepository.GetById(id);

        var product = orderItemRepository.GetProductById(orderItemRequest.ProductId);
        var order = orderItemRepository.GetOrderById(orderItemRequest.OrderId);

        orderItem.Price = orderItemRequest.Price;
        orderItem.Quantity = orderItemRequest.Quantity;
        orderItem.ProductId = product.Id;
        orderItem.Product = product;
        orderItem.OrderId = order.Id;
        orderItem.Order = order;

        orderItemRepository.Update(id, orderItem);

        var orderItemResponse = new OrderItemResponse
        {
            Id = orderItem.Id,
            Price = orderItem.Price,
            Quantity = orderItem.Quantity,
            ProductId = orderItem.ProductId,
            Product = orderItem.Product,
            OrderId = orderItem.OrderId,
            Order = orderItem.Order
        };

        return orderItemResponse;
    }

    public OrderItemResponse Delete(Guid id)
    {
        var orderItem = orderItemRepository.Delete(id);

        var orderItemResponse = new OrderItemResponse
        {
            Id = orderItem.Id,
            Price = orderItem.Price,
            Quantity = orderItem.Quantity,
            ProductId = orderItem.ProductId,
            Product = orderItem.Product,
            OrderId = orderItem.OrderId,
            Order = orderItem.Order
        };

        return orderItemResponse;
    }

    public OrderItemResponse GetById(Guid id)
    {
        var orderItem = orderItemRepository.GetById(id);

        var orderItemResponse = new OrderItemResponse
        {
            Id = orderItem.Id,
            Price = orderItem.Price,
            Quantity = orderItem.Quantity,
            ProductId = orderItem.ProductId,
            Product = orderItem.Product,
            OrderId = orderItem.OrderId,
            Order = orderItem.Order
        };

        return orderItemResponse;
    }
}