using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Project.API.Configurations
{
    public static class CorsSetup
    {
        public static void AddCorsSetup(this IServiceCollection services)
        {
            services.AddCors(
                s => s.AddPolicy("DefaultPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                }));
        }

        public static void UseCorsSetup(this IApplicationBuilder app)
        {
            app.UseCors("DefaultPolicy");
        }
    }
}
