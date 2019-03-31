using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;

namespace AgriculturalProducts.Web.Admin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog()
                .UseUrls("https://localhost:44387/")
                .UseIISIntegration()
                .Build();

        public static void CreateFileLogger()
        {
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Error()
                            .MinimumLevel.Override("SerilogDemo", LogEventLevel.Information)
                            .WriteTo.File("Logs/Admin.log",
                                    LogEventLevel.Information, // Minimum Log level
                                    rollingInterval: RollingInterval.Month, // This will append time period to the filename like Example20180316.txt
                                    retainedFileCountLimit: null,
                                    rollOnFileSizeLimit: true,
                                    fileSizeLimitBytes: 50000,
                                    outputTemplate: "{Timestamp:dd-MMM-yyyy HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",  // Set custom file format
                                    shared: true // Shared between multi-process shared log files
                                    )
                            .CreateLogger();
        }

    }
}
