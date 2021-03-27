using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Object_B.Models.Context;
using Object_B.Models;
using System.Text.Json;

namespace Object_B.Controllers
{
    public class MapCompController : Controller
    {
        AllDataContext context;
        public MapCompController(AllDataContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateMap(int selectCom = 1)
        {
            ViewBag.Select = context.Companies.Where(u => u.CompanyId == selectCom).Select(u => u.NameCompany).First();
            ViewBag.Rooms = context.Rooms.Where(u => u.Company.CompanyId == selectCom).Select(u => u.NameRoom);
            ViewBag.Companies = context.Companies.Select(u => u.NameCompany);
            return View();
        }

        [HttpGet]
        public void CreateRoom(string newRoom)
        {
            Console.WriteLine(newRoom);
        }

        [HttpGet]
        public string Test()
        {
            var t = JsonConvert.SerializeObject((IEnumerable<Room>)context.Rooms);
            Console.WriteLine(t);
            return t;
        }
    }
}
