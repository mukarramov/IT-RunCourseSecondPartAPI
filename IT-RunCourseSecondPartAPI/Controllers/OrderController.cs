using IT_RunCourseSecondPartAPI.DTOs;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Repositories.Repository;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class OrderController : ControllerBase
{
    [HttpPost]
    public IActionResult Create(Order order, [FromServices] IOrderRepository orderRepository)
    {
        orderRepository.Create(order);

        var orderResponse = order.Adapt<OrderDto>();

        return Ok(orderResponse);
    }

    [HttpGet]
    public IActionResult GetAll([FromServices] IOrderRepository orderRepository)
    {
        orderRepository.GetAll();

        var orderResponse = OrderRepository.Orders.Adapt<List<OrderDto>>();

        return Ok(orderResponse);
    }
}