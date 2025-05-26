using MapsterMapper;

namespace IT_RunCourseSecondPartAPI.MinimalAPI.Extensions;

public static class MapsterExtensions
{
    public static void AddMapster(this IServiceCollection service)
    {
        service.AddSingleton<IMapper, MapsterMapper.Mapper>();
    }
}