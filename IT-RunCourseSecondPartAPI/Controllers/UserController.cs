using IT_RunCourseSecondPartAPI.DTOs;
using IT_RunCourseSecondPartAPI.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    public static readonly List<User> Users = [];

    [HttpPost]
    public IActionResult AddUser(User user)
    {
        Users.Add(user);

        var userResponse = user.Adapt<UserResponse>();

        return Ok(userResponse);
    }

    [HttpGet]
    public IActionResult GetAllUser()
    {
        var userResponse = Users.Adapt<List<UserResponse>>();

        return Ok(userResponse);
    }

    [HttpPut("[action]")]
    public IActionResult UpdateUser(User user)
    {
        var findUser = Users.FirstOrDefault(x => x.Id == user.Id);

        if (findUser == null)
        {
            return NotFound($"user by id: {user.Id} does not exist!");
        }

        findUser.Address = user.Address;
        findUser.Email = user.Email;
        findUser.FullName = user.FullName;
        findUser.Password = user.Password;
        findUser.Roule = user.Roule;
        findUser.RegisteredAt = user.RegisteredAt;

        var userResponse = user.Adapt<UserResponse>();

        return Ok(userResponse);
    }

    [HttpDelete]
    public IActionResult DeleteUser(int id)
    {
        var findUser = Users.FirstOrDefault(x => x.Id == id);

        if (findUser == null)
        {
            return NotFound($"user by id: {id} does not exist");
        }

        Users.RemoveAt(id);
        return Ok();
    }
}