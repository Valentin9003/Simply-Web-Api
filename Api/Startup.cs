using Api.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Api.Infrastructure.Extensions;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) =>
            services.AddInMemoryDatabase()
                     .AddApplicationServices()
                     .AddMemoryCache()
                     .AddSwagger()
                     .AddApiController();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) =>
            app.UseRouting()
               .UseSwaggerUI()
               .InitializeDatabase() 
               .UseEndpoints(endpoints =>
               {
                endpoints.MapControllers();
               });
    }
}
