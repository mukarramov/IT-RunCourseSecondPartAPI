using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IT_RunCourseSecondPartAPI.Extensions;

/// <summary>
/// This is a minimal api and also the extended method
/// </summary>
public static class UserApiExtension
{
    public static void MapUserApis(this WebApplication app)
    {
        app.MapGet("api/user",
            ([FromServices] IGenericRepository<User> genericRepository) =>
            {
                return Results.Ok(genericRepository.GetAll());
            });
    }
}