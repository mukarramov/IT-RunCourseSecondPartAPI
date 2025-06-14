using Serilog;
using Serilog.Formatting.Json;

namespace IT_RunCourseSecondPartAPI.Extensions;

public static class LogConfigurationExtension
{
    public static void ConfigureSerilog(this IHostBuilder host)
    {
        host.UseSerilog((ctx, lc) =>
        {
            lc.WriteTo.Console();
            lc.WriteTo.Seq("http://localhost:5341");
            lc.WriteTo.File(new JsonFormatter(), "log.txt");
        });
    }
}