using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller][action]")]
public class OrderItemController(IOrderItemService orderItemService) : ControllerBase
{
    [HttpPost]
    public IActionResult Add(OrderItemCreate orderItemRequest)
    {
        return Ok(orderItemService.Add(orderItemRequest));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(orderItemService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(orderItemService.GetById(id));
    }

    [HttpPut]
    public IActionResult Update(Guid id, OrderItemCreate orderItemRequest)
    {
        return Ok(orderItemService.Update(id, orderItemRequest));
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        return Ok(orderItemService.Delete(id));
    }
}