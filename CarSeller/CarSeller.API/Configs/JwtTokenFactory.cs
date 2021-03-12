using CarSeller.Entities.Models;
using CarSeller.ViewModels.UserViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarSeller.API.Configs
{
    /// <summary>
    /// The JwtTokenFactory method is responsible for generating the user's token.
    /// </summary>
    public static class JwtTokenFactory
    {
        public static GenerateJwtTokenUserViewModel GenerateJwtToken(User entity, IConfiguration configuration)
        {
            var securityKeyStr = configuration["Jwt:SecretKey"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKeyStr));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var issuer = configuration["Jwt:Issuer"];
            var audience = configuration["Jwt:Audience"];
            var expires = DateTime.Now.AddMinutes(30);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, entity.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(issuer: issuer,
                                             audience: audience,
                                             claims: claims,
                                             expires: expires,
                                             signingCredentials: credentials);

            return new GenerateJwtTokenUserViewModel { Token = new JwtSecurityTokenHandler().WriteToken(token) };
        }
    }
}
