using Application.Dtos.CreatedRequest;
using Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public IActionResult Add(UserCreate userCreate)
    {
        return Ok(userService.Add(userCreate));
    }

    [HttpGet]
    public IActionResult GetAllUser()
    {
        return Ok(userService.GetAll());
    }

    [HttpPut]
    public IActionResult UpdateUser(Guid id, UserCreate userCreate)
    {
        var userResponse = userService.Update(id, userCreate);

        if (userResponse is null)
        {
            return NotFound();
        }

        return Ok(userResponse);
    }

    [HttpDelete]
    public IActionResult DeleteUser(Guid userId)
    {
        var userResponse = userService.Delete(userId);

        if (userResponse is null)
        {
            return NotFound();
        }

        return Ok(userResponse);
    }

    [HttpGet]
    public IActionResult GetById(Guid id)
    {
        var userResponse = userService.GetById(id);

        if (userResponse is null)
        {
            return NotFound();
        }

        return Ok(userResponse);
    }
}