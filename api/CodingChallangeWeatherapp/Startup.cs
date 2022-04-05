using CodingChallangeWeatherapp.Data;
using Microsoft.EntityFrameworkCore;

namespace CodingChallangeWeatherapp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
                options
                .UseSqlServer(Configuration.GetConnectionString("DataContext"), o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

            services.AddControllers();

            services.AddHttpContextAccessor();

            // Only allow this in development so its easier to work with requests in development !!
            services.AddCors(opt => {
                opt.AddPolicy("CorsPolicy", policy => {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, nextMiddleware) =>
            {
                context.Response.Headers.Add("strict-transport-security", "max-age=31536000; includeSubDomains");
                context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Add("referrer-policy", "no-referrer-when-downgrade");
                context.Response.Headers.Add("permisions-policy", "");

                await nextMiddleware();
            });

            app.UseRouting();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToController("Index", "Fallback");
            });
        }
    }
}
