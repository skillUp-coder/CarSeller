using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace CarSeller.API.Config
{
    /// <summary>
    /// The SwaggerConfig class is responsible for adding configurations to startup.
    /// </summary>
    public static class SwaggerConfig
    {
        /// <summary>
        /// The Set Swagger method is designed to add and Swagger config settings.
        /// </summary>
        /// <param name="app">Designed to add configurations to IApplicationBuilder.</param>
        /// <param name="configuration">Designed to get configuration providers.</param>
        public static void SetSwagger(this IApplicationBuilder app, IConfiguration configuration) 
        {
            var jsonRoute = configuration["SwaggerOptions:JsonRoute"];
            var description = configuration["SwaggerOptions:Description"];

            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint(jsonRoute, description);
            });
        }
    }
}
