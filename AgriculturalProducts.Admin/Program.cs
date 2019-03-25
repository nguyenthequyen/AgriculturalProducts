using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace AgriculturalProducts.Web.Admin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateFileLogger();
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog()
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
