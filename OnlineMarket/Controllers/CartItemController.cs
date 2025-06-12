using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CartItemController(ICartItemService cartItemService) : ControllerBase
{
    [HttpPost]
    public IActionResult Add(CartItemCreate cartItemCreate)
    {
        return Ok(cartItemService.Add(cartItemCreate));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(cartItemService.GetAll());
    }

    [HttpPut]
    public IActionResult Update(Guid id, CartItemCreate cartItemCreate)
    {
        return Ok(cartItemService.Update(id, cartItemCreate));
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        return Ok(cartItemService.Delete(id));
    }

    [HttpGet]
    public IActionResult GetById(Guid id)
    {
        return Ok(cartItemService.GetById(id));
    }
}