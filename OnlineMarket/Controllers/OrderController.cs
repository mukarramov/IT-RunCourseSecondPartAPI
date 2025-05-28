using IT_RunCourseSecondPartAPI.DTOs.Requests;
using IT_RunCourseSecondPartAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class OrderController(IOrderService orderService) : ControllerBase
{
    [HttpPost]
    public IActionResult Add(OrderRequest orderRequest)
    {
        return Ok(orderService.Add(orderRequest));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(orderService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(orderService.GetById(id));
    }

    [HttpPut]
    public IActionResult Update(Guid id, OrderRequest orderRequest)
    {
        return Ok(orderService.Update(id, orderRequest));
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        return Ok(orderService.Delete(id));
    }
}