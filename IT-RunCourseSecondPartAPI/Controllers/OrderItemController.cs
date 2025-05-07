using IT_RunCourseSecondPartAPI.DTOs;
using IT_RunCourseSecondPartAPI.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller][action]")]
public class OrderItemController : ControllerBase
{
    private static readonly List<OrderItem> OrderItems = [];

    [HttpPost]
    public IActionResult Create(OrderItem orderItem)
    {
        var product = ProductController.Products;
        var order = OrderController.Orders;
        
        var lookForProduct = product.SingleOrDefault(x => x.Id == orderItem.ProductId);
        if (lookForProduct == null)
        {
            return BadRequest($"the product with id: {orderItem.ProductId} does not exist!");
        }

        var lookForOrder = order.SingleOrDefault(x => x.Id == orderItem.OrderId);
        if (lookForOrder == null)
        {
            return BadRequest($"the order with id: {orderItem.Id} does not exist!");
        }

        orderItem.ProductId = lookForProduct.Id;
        orderItem.Product = lookForProduct;
        orderItem.OrderId = lookForOrder.Id;
        orderItem.Order = lookForOrder;

        OrderItems.Add(orderItem);

        var orderItemResponse = orderItem.Adapt<OrderItemDto>();

        return Ok(orderItemResponse);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var orderItemResponse = OrderItems.Adapt<List<OrderItemDto>>();

        return Ok(orderItemResponse);
    }
}