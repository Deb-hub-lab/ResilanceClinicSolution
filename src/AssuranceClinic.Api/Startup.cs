using AssuranceClinic.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Diagnostics;

namespace AssuranceClinic.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AssuranceClinic API", Version = "v1" });
            });

            var conn = Configuration.GetConnectionString("DefaultConnection") 
                ?? throw new Exception("Set DefaultConnection in appsettings.json");

            services.AddInfrastructureServices(conn);
            services.AddApplicationServices();
        }

        public void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                // 🔹 Auto open swagger in default browser when app starts
                var swaggerUrl = "https://localhost:51780/swagger/index.html";
                Task.Run(() =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = swaggerUrl,
                            UseShellExecute = true
                        });
                    }
                    catch
                    {
                        Console.WriteLine($"Swagger UI available at: {swaggerUrl}");
                    }
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
