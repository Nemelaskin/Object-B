using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Object_B.Models.Context;
using Object_B.Models;
using Microsoft.AspNetCore.Authorization;

namespace Object_B.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private AdminViewModel adminModel = new AdminViewModel();

        public AdminController(AllDataContext context)
        {
            adminModel.role = (from i in context.Roles where i.NameRole != "" select i.NameRole).ToList();
            adminModel.room = (from i in context.Rooms where i.NameRoom != "" select i.NameRoom).ToList();
            adminModel.position = (from i in context.Positions where i.NamePosition != "" select i.NamePosition).ToList();
            adminModel.user = (from i in context.Users where i.SecondName != "" select i.SecondName).ToList();
            adminModel.company = (from i in context.Companies where i.NameCompany != "" select i.NameCompany).ToList(); 
            adminModel.sensor = (from i in context.Sensors where i.NameSensor != "" select i.NameSensor).ToList(); 
            adminModel.visit = (from i in context.Visits where i.VisitId != 0 select i.VisitId.ToString()).ToList();

        }
        public IActionResult Main()
        {
            return View(adminModel);
        }
        
    }
}
