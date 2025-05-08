using IT_RunCourseSecondPartAPI.Repositories.Repository;

namespace IT_RunCourseSecondPartAPI.Extensions;

public static class UserApiExtension
{
    public static void MapUserApis(this WebApplication app)
    {
        app.MapGet("api/user", () =>
        {
            var users = UserRepository.Users;
            
            return Results.Ok(users);
        });
    }
}