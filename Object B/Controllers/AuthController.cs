using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Object_B.Models;
using Object_B.Models.Context;
using Microsoft.Extensions.Options;
using Auth.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Object_B.Services;

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
            var user = AutherizationUser(request.Email);

            if(BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                JWT jwt = new JWT(authOptions);
                var token = jwt.GenerateJWT(user);
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

        private User AutherizationUser(string email)
        {
            return _context.Users.Include(u => u.Role).FirstOrDefault<User>(u => u.Email == email);
        }
    }
}
