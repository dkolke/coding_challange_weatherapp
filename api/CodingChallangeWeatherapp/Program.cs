using CodingChallangeWeatherapp.Data;
using Microsoft.EntityFrameworkCore;

namespace CodingChallangeWeatherapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();
                try
                {
                    var context = services.GetRequiredService<DataContext>();
                    context.Database.Migrate();
                    logger.Log(LogLevel.Information, "Updated database to the latest mirgation");

                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occured during mirgation");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}