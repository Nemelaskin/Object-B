using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Object_B.Models.Context;
using Object_B.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Object_B.Models;


namespace Object_B.Controllers
{
    public class AccountController : Controller
    {
        private AllDataContext _context;
        public AccountController(AllDataContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Login(string phone, string password)
        {
            var user = _context.Users.Include(u => u.Role).FirstOrDefault<User>(u => u.Phone == phone && u.Password == password);
            if (user == null)
            {
                return View();
            }

            else if (user.Role.NameRole == "admin") // join to admin panel
            {
                autoth(user);

                return Redirect("../Views/Admin/Main");
            }

            else                                    // joib to user panel
            {
                autoth(user);
                return View();
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        private async void autoth(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.FirstName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); // exit autorisation

    }
}
