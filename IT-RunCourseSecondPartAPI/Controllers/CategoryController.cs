using IT_RunCourseSecondPartAPI.DTOs;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Repository;
using IT_RunCourseSecondPartAPI.Services.Interface;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CategoryController(IService<Category> categoryService) : ControllerBase
{
    [HttpPost]
    public IActionResult Add(Category category)
    {
        categoryService.Add(category);

        var categoryResponse = category.Adapt<CategoryDto>();

        return Ok(categoryResponse);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        categoryService.GetAll();

        var categoryResponse = CategoryRepository.Categories.Adapt<List<CategoryDto>>();

        return Ok(categoryResponse);
    }

    [HttpPut]
    public IActionResult Update(Guid id, Category category)
    {
        var categoryResponse = categoryService.Update(id, category);

        return Ok(categoryResponse);
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        categoryService.Delete(id);

        return Ok();
    }
}