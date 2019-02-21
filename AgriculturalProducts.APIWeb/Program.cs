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

namespace AgriculturalProducts.APIWeb
{
    public class Program
    {
        private static string _environmentName;
        public static void Main(string[] args)
        {
          
            CreateWebHostBuilder(args).UseSerilog().Build().Run();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .AddJsonFile($"appsettings.{_environmentName}.json", optional: true, reloadOnChange: true)
                        .Build();
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel
                .Information()
                .MinimumLevel.Override("SerilogDemo", LogEventLevel.Information)
                .ReadFrom.Configuration(configuration)
                .WriteTo.File(@"Logs\log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
