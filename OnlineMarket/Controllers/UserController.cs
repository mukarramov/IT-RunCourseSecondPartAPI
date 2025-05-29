using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.Services.Interface;
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

    [HttpPut("[action]")]
    public IActionResult UpdateUser(Guid id, UserCreate userCreate)
    {
        var userResponse = userService.Update(id, userCreate);

        return Ok(userResponse);
    }

    [HttpDelete]
    public IActionResult DeleteUser(Guid userId)
    {
        var userResponse = userService.Delete(userId);

        return Ok(userResponse);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var userResponse = userService.GetById(id);

        return Ok(userResponse);
    }
}