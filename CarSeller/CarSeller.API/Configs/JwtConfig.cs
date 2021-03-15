using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace CarSeller.API.Config
{
    /// <summary>
    /// The JwtConfig class is responsible for adding configurations to startup.
    /// </summary>
    public static class JwtConfig
    {
        /// <summary>
        /// SetJwtBearer method is responsible for adding configurations for Jwt Token and Authentication.
        /// </summary>
        /// <param name="services">Designed to add configurations to IServiceCollectio.</param>
        /// <param name="configuration">Designed to get configuration providers.</param>
        public static void SetJwtBearer(this IServiceCollection services, IConfiguration configuration)
        {
            var issuerDev = configuration["Jwt:Issuer"];
            var audienceDev = configuration["Jwt:Audience"];
            var key = configuration["Jwt:SecretKey"];

            services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(ber =>
            {
                ber.RequireHttpsMetadata = false;
                ber.SaveToken = true;
                ber.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuerDev,
                    ValidAudience = audienceDev,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
