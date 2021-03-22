using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

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
        public static void SetSwagger(this IApplicationBuilder app, 
                                           IConfiguration configuration) 
        {
            var jsonRoute = configuration["SwaggerOptions:JsonRoute"];
            var description = configuration["SwaggerOptions:Description"];

            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint(jsonRoute, description);
            });
        }

        /// <summary>
        /// The SetSwaggerSecurity method adds security schemas.
        /// </summary>
        /// <param name="services">Designed to add configurations to IServiceCollection.</param>
        /// <param name="configuration">Designed to get configuration providers.</param>
        public static void SetSwaggerSecurity(this IServiceCollection services, 
                                                   IConfiguration configuration) 
        {
            services.AddSwaggerGen(opt => 
            {
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = configuration["SwaggerSecurity:Name"],
                    Description = configuration["SwaggerSecurity:Description"],
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = configuration["SwaggerSecurity:Scheme"], 
                    BearerFormat = configuration["SwaggerSecurity:BearerFormat"],
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                opt.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new List<string> { }}
                });

                var basicSecurityScheme = new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = configuration["SwaggerSecurity:BasicSecurityScheme"],
                    Reference = new OpenApiReference 
                    { 
                        Id = configuration["SwaggerSecurity:ReferenceId"], 
                        Type = ReferenceType.SecurityScheme 
                    }
                };
                opt.AddSecurityDefinition(basicSecurityScheme.Reference.Id, basicSecurityScheme);
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {basicSecurityScheme, new List<string> { }}
                });
            });
        }
    }
}
