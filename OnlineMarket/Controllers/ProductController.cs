using IT_RunCourseSecondPartAPI.DTOs.Requests;
using IT_RunCourseSecondPartAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpPost]
    public IActionResult Add(ProductRequest product)
    {
        return Ok(productService.Add(product));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(productService.GetAll());
    }

    [HttpPut]
    public IActionResult Update(Guid id, ProductRequest product)
    {
        return Ok(productService.Update(id, product));
    }

    [HttpDelete]
    public IActionResult Delete(Guid productId)
    {
        return Ok(productId);
    }
}