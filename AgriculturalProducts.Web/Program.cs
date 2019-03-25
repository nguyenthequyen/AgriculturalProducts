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

namespace AgriculturalProducts.APIWeb
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
                .UseUrls("https://localhost:44361/")
                .Build();

        public static void CreateFileLogger()
        {
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Information()
                            .MinimumLevel.Override("SerilogDemo", LogEventLevel.Information)
                            .WriteTo.File("Logs/Client.log",
                                    LogEventLevel.Information, // Minimum Log level
                                    rollingInterval: RollingInterval.Day, // This will append time period to the filename like Example20180316.txt
                                    retainedFileCountLimit: null,
                                    fileSizeLimitBytes: null,
                                    outputTemplate: "{Timestamp:dd-MMM-yyyy HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",  // Set custom file format
                                    shared: true // Shared between multi-process shared log files
                                    )
                            .CreateLogger();
        }
    }
}
