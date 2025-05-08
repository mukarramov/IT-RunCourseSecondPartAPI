using IT_RunCourseSecondPartAPI.DTOs;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Repositories.Repository;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller][action]")]
public class OrderItemController : ControllerBase
{
    [HttpPost]
    public IActionResult Create(OrderItem orderItem, [FromServices] IOrderItemRepository orderItemRepository)
    {
        orderItemRepository.Create(orderItem);

        var orderItemResponse = orderItemRepository.Adapt<OrderItemDto>();

        return Ok(orderItemResponse);
    }

    [HttpGet]
    public IActionResult GetAll([FromServices] IOrderItemRepository orderItemRepository)
    {
        orderItemRepository.GetAll();

        var orderItemResponse = OrderItemRepository.OrderItems.Adapt<List<OrderItemDto>>();

        return Ok(orderItemResponse);
    }
}