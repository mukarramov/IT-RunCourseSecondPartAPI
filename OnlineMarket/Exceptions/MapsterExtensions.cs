using MapsterMapper;

namespace IT_RunCourseSecondPartAPI.Exceptions;

public static class MapsterExtensions
{
    public static void AddMapster(this IServiceCollection service)
    {
        service.AddSingleton<IMapper, MapsterMapper.Mapper>();
    }
}