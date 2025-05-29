using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    [HttpPost]
    public IActionResult Add(CategoryCreate categoryCreate)
    {
        return Ok(categoryService.Add(categoryCreate));
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
    public IActionResult Update(Guid id, CategoryCreate categoryCreate)
    {
        return Ok(categoryService.Update(id, categoryCreate));
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        return Ok(categoryService.Delete(id));
    }
}