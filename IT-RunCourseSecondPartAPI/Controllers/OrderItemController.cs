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
        var order = OrderController.Orders;
        var product = ProductController.Products;

        var lookForOrder = order.SingleOrDefault(x => x.Id == orderItem.OrderId);
        if (lookForOrder == null)
        {
            return BadRequest($"the order with id: {orderItem.Id} does not exist!");
        }

        var lookForProduct = product.SingleOrDefault(x => x.Id == orderItem.ProductId);
        if (lookForProduct == null)
        {
            return BadRequest($"the product with id: {orderItem.ProductId} does not exist!");
        }

        orderItem.Order = lookForOrder;
        orderItem.Product = lookForProduct;
        orderItem.ProductId = lookForProduct.Id;
        orderItem.OrderId = lookForOrder.Id;

        OrderItems.Add(orderItem);

        var orderItemResponse = orderItem.Adapt<OrderItemResponse>();

        return Ok(orderItemResponse);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var orderItemResponse = OrderItems.Adapt<List<OrderItemResponse>>();

        return Ok(orderItemResponse);
    }
}