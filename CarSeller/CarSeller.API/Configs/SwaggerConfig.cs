using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace CarSeller.API.Config
{
    public static class SwaggerConfig
    {
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
