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

    [HttpPut]
    public IActionResult Update(Guid id, CategoryCreate categoryCreate)
    {
        var categoryResponse = categoryService.Update(id, categoryCreate);

        if (categoryResponse is null)
        {
            return NotFound();
        }

        return Ok(categoryResponse);    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        var categoryResponse = categoryService.Delete(id);

        if (categoryResponse is null)
        {
            return NotFound();
        }

        return Ok(categoryResponse);    }

    [HttpGet]
    public IActionResult GetById(Guid id)
    {
        var categoryResponse = categoryService.GetById(id);

        if (categoryResponse is null)
        {
            return NotFound();
        }

        return Ok(categoryResponse);    }
}