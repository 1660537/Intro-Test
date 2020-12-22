using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IntroTest.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace IntroTest.Shared
{
    public static class AuthenticationConfig
    {
        public static string GenerateJSONWebToken(Passcode passcode)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DCE3FDD385EAF50DDAA3287FB7B89D42DFEE3BC56519593B8A11E7621EA967C1"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("IdRole", passcode.IdRole.ToString()),
                new Claim("Code", passcode.Code),
            };

            var token = new JwtSecurityToken("https://localhost:44351",
                "https://localhost:44351",
            claims,
            DateTime.UtcNow,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        internal static TokenValidationParameters tokenValidationParameters;

        public static void ConfigureJwtAuthentication(this IServiceCollection services)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DCE3FDD385EAF50DDAA3287FB7B89D42DFEE3BC56519593B8A11E7621EA967C1"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                ValidIssuer = "https://localhost:44351",
                ValidateLifetime = true,
                ValidAudience = "https://localhost:44351",
                RequireSignedTokens = true,
                IssuerSigningKey = credentials.Key,
                ClockSkew = TimeSpan.FromMinutes(10)
            };
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = tokenValidationParameters;
                options.RequireHttpsMetadata = false;
            });
        }
    }
}
