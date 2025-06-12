using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ShoppingCartController(IShoppingCartService shoppingCartService) : ControllerBase
{
    [HttpPost]
    public IActionResult Add(ShoppingCartCreate shoppingCartCreate)
    {
        return Ok(shoppingCartService.Add(shoppingCartCreate));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(shoppingCartService.GetAll());
    }

    [HttpPut]
    public IActionResult Update(Guid id, ShoppingCartCreate shoppingCartCreate)
    {
        return Ok(shoppingCartService.Update(id, shoppingCartCreate));
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        return Ok(shoppingCartService.Delete(id));
    }

    [HttpGet]
    public IActionResult GetById(Guid id)
    {
        return Ok(shoppingCartService.GetById(id));
    }
}