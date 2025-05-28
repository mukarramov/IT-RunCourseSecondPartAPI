using IT_RunCourseSecondPartAPI.DTOs.Requests;
using IT_RunCourseSecondPartAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    [HttpPost]
    public IActionResult Add(CategoryRequest categoryRequest)
    {
        return Ok(categoryService.Add(categoryRequest));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(categoryService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(categoryService.GetById(id));
    }

    [HttpPut]
    public IActionResult Update(Guid id, CategoryRequest categoryRequest)
    {
        return Ok(categoryService.Update(id, categoryRequest));
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        return Ok(categoryService.Delete(id));
    }
}