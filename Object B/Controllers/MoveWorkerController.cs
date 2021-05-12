using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Object_B.Models.Context;
using Object_B.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Object_B.Controllers
{
    public class MoveWorkerController : Controller
    {
        AllDataContext context;
        public MoveWorkerController(AllDataContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public string GetSensors()
        {
            var sensocrs = context.Sensors;
            var str = JsonConvert.SerializeObject(sensocrs);
            return str;
        }
    }
}
