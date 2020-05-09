using Api.Data;
using Api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Api.Infrastructure.Filters;

namespace Api.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInMemoryDatabase(this IServiceCollection services) =>
            services.AddDbContext<ApiDbContext>(option => option.UseInMemoryDatabase(ProjectConstants.InMemoryDatabaseName));

        public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
            services.AddTransient<IApiService, ApiService>();

        public static IServiceCollection AddSwagger(this IServiceCollection services)
           => services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc(
                   ProjectConstants.SwaggerApiVersion,
                   new OpenApiInfo
                   {
                       Title = ProjectConstants.SwaggerApiTitle,
                       Version = ProjectConstants.SwaggerApiVersion
                   });
           });

        public static void AddApiController(this IServiceCollection services)
          =>  services.AddControllers(option => option.Filters.Add<ModelNotFoundActionFilter>());
    }
}
