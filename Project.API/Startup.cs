using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.API.Configurations;

namespace Project.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {   
            services.AddControllers();            

            EntityFrameworkSetup.AddEntityFrameworkSetup(services, Configuration);

            DependencyInjection.Register(services);

            AutoMapperSetup.AddAutoMapperSetup(services);

            CorsSetup.AddCorsSetup(services);

            SwaggerSetup.AddSwaggerSetup(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            CorsSetup.UseCorsSetup(app);
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            SwaggerSetup.UseSwaggerSetup(app);
        }
    }
}
