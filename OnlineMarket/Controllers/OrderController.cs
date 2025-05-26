using IT_RunCourseSecondPartAPI.DTOs;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Repository;
using IT_RunCourseSecondPartAPI.Services.Interface;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class OrderController(IService<Order> orderService) : ControllerBase
{
    [HttpPost]
    public IActionResult Add(Order order)
    {
        orderService.Add(order);

        var orderResponse = order.Adapt<OrderDto>();

        return Ok(orderResponse);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var orderResponse = OrderRepository.Orders.Adapt<List<OrderDto>>();

        return Ok(orderResponse);
    }
}