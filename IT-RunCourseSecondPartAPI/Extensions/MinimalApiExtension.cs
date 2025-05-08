namespace IT_RunCourseSecondPartAPI.Extensions;

public static class MinimalApiExtension
{
    public static void MapMinimalApis(this WebApplication app)
    {
        app.MapUserApis();
    }
}