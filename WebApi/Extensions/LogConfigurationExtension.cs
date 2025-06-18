using Serilog;

namespace IT_RunCourseSecondPartAPI.Extensions;

public static class LogConfigurationExtension
{
    public static void ConfigureSerilog(this IHostBuilder host)
    {
        host.UseSerilog(configureLogger: (_, lc) =>
        {
            lc.WriteTo.Console();
            lc.WriteTo.Seq(serverUrl: "http://localhost:5341");
            lc.WriteTo.File(path: "log.txt", rollingInterval: RollingInterval.Day);
        });
    }
}