using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace CleverbitSoftware.WebApi
{
    public class Program
    {
        public static string LoggingSectionKey => "Logging";
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection(LoggingSectionKey));
                    logging.AddConsole();
                    logging.AddDebug();
                    logging.AddEventLog();
                    logging.AddEventSourceLogger();
                })
                .UseStartup<Startup>();
    }
}