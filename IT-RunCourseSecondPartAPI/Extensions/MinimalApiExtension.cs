namespace IT_RunCourseSecondPartAPI.Extensions;

/// <summary>
/// This is an extended class for mapping (from program.cs)
/// </summary>
public static class MinimalApiExtension
{
    public static void MapMinimalApis(this WebApplication app)
    {
        app.MapUserApis();
    }
}