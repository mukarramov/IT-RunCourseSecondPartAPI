using IT_RunCourseSecondPartAPI.DTOs;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Repository;
using IT_RunCourseSecondPartAPI.Services.Interface;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController(IService<User> service) : ControllerBase
{
    [HttpPost]
    public IActionResult AddUser(User user)
    {
        service.Add(user);

        var userResponse = user.Adapt<UserDto>();

        return Ok(userResponse);
    }

    [HttpGet]
    public IActionResult GetAllUser()
    {
        var userResponse = UserRepository.Users.Adapt<List<UserDto>>();

        return Ok(userResponse);
    }

    [HttpPut("[action]")]
    public IActionResult UpdateUser(Guid id, User user)
    {
        service.Update(id, user);

        var userResponse = user.Adapt<UserDto>();

        return Ok(userResponse);
    }

    [HttpDelete]
    public IActionResult DeleteUser(Guid userId)
    {
        service.Delete(userId);

        return Ok(true);
    }
}