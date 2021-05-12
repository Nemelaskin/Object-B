using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Object_B.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Object_B.Models.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Object_B.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        AllDataContext context;
        public HomeController(ILogger<HomeController> logger, AllDataContext context)
        {
            this.context = context;
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult News()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
