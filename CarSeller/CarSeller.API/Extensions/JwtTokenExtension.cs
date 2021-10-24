using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.UserViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CarSeller.API.Extensions
{
    /// <summary>
    ///     The JwtTokenExtension class is responsible for generating the user's token.
    /// </summary>
    public static class JwtTokenExtension
    {
        /// <summary>
        ///     The GenerateJwtTokenUserViewModel method to generate the user's token.
        /// </summary>
        /// <param name="entity">
        ///     The User object to create the token.
        /// </param>
        /// <param name="configuration">
        ///     Designed to get configuration providers.
        /// </param>
        /// <returns>
        ///     A task that represents a token generation operation.
        /// </returns>
        public static GenerateJwtTokenUserViewModel GenerateJwtToken(
            User entity, 
            IConfiguration configuration)
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

            var token = new JwtSecurityToken(
                issuer, 
                audience, 
                claims, 
                expires: expires, 
                signingCredentials: credentials);

            return new GenerateJwtTokenUserViewModel { Token = new JwtSecurityTokenHandler().WriteToken(token) };
        }
    }
}