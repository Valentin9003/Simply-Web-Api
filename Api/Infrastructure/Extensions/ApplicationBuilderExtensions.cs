using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app)
           => app
               .UseSwagger()
               .UseSwaggerUI(options =>
               {
                   options.SwaggerEndpoint(ProjectConstants.SwaggerEndpoint, ProjectConstants.SwaggerApiTitle);
                   options.RoutePrefix = string.Empty;
               });
    }
}
