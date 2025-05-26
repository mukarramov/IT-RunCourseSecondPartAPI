using IT_RunCourseSecondPartAPI.DTOs;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Repository;
using IT_RunCourseSecondPartAPI.Services.Interface;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller][action]")]
public class OrderItemController(IService<OrderItem> orderItemService) : ControllerBase
{
    [HttpPost]
    public IActionResult Add(OrderItem orderItem)
    {
        orderItemService.Add(orderItem);

        var orderItemResponse = orderItem.Adapt<OrderItemDto>();

        return Ok(orderItemResponse);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var orderItemResponse = OrderItemRepository.OrderItems.Adapt<List<OrderItemDto>>();

        return Ok(orderItemResponse);
    }
}