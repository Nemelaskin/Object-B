using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Object_B.Models;
using Object_B.Models.Context;
using Microsoft.Extensions.Options;
using Auth.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Object_B.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private AllDataContext _context;
        private readonly IOptions<AuthOptions> authOptions;
        public AuthController(AllDataContext context, IOptions<AuthOptions> authOptions)
        {
            _context = context;
            this.authOptions = authOptions;
        }
        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody]Login request)
        {
            var user = AutherizationUser(request.Email, request.Password);

            if(user != null)
            {
                var token = GenerateJWT(user);
                return Ok(new
                {
                    access_token = token
                });
            }
            return Unauthorized();
        }
        [HttpGet]
        [Route ("test")]
        [Authorize(Roles = "admin")]
        
        public IActionResult TestAuth()
        {
            return Ok("Okey");
        }

        private User AutherizationUser(string email, string password)
        {
            return _context.Users.Include(u => u.Role).FirstOrDefault<User>(u => u.Email == email && u.Password == password);
        }

        private string GenerateJWT(User user)
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
