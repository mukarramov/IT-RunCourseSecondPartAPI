using IT_RunCourseSecondPartAPI.DTOs;
using IT_RunCourseSecondPartAPI.MinimalAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.MinimalAPI.Repositories.Repository;
using IT_RunCourseSecondPartAPI.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.MinimalAPI.Extensions;

/// <summary>
/// This is a minimal api and also the extended method
/// </summary>
public static class UserApiExtension
{
    public static void MapUserApis(this WebApplication app)
    {
        app.MapPost("api/create/user", (User user, [FromServices] IRepository<User> repository) =>
        {
            repository.Create(user);

            var userResponse = user.Adapt<UserDto>();

            return Results.Ok(user);
        });

        app.MapGet("api/getAll/user",
            ([FromServices] IRepository<User> repository) =>
            {
                var usersResponse = Repository<User>.Entities.Adapt<List<UserDto>>();
                return Results.Ok(repository.GetAll());
            });
    }
}