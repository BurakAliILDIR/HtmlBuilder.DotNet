﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HtmlBuilder.API.Configs;
using HtmlBuilder.API.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HtmlBuilder.API.Infrastructure.Jwt
{
    public class JwtHelper : IJwtHelper
    {
        private readonly JwtSettings _jwtSettings;

        public JwtHelper(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public string CreateToken(AppUser user)
        {
            var issuer = _jwtSettings.Issuer;
            var audience = _jwtSettings.Audience;
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenMinute),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}