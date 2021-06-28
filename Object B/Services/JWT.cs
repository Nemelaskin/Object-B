using Auth.Common;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Object_B.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Object_B.Services
{
    public class JWT
    {
        private readonly IOptions<AuthOptions> authOptions;
        public JWT(IOptions<AuthOptions> authOptions)
        {
            this.authOptions = authOptions;
        }

        public string GenerateJWT(User user)
        {
            var authParams = authOptions.Value;

            var securtiyKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securtiyKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim (JwtRegisteredClaimNames.Email, user.Email),
                new Claim (JwtRegisteredClaimNames.Sub, user.UserId.ToString())
            };

            claims.Add(new Claim("role", user.Role.NameRole));

            var token = new JwtSecurityToken(authParams.Issuer, authParams.Audience, claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
