using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Object_B.Models.Context;
using Object_B.Models;

namespace Object_B.Controllers
{
    public class AdminController : Controller
    {
        private AdminViewModel temp = new AdminViewModel();
        private AllDataContext context;

        public AdminController(AllDataContext context)
        {
            this.context = context;
            temp.role = (from i in context.Roles where i.NameRole != "" select i.NameRole).ToList();
            temp.room = (from i in context.Rooms where i.NameRoom != "" select i.NameRoom).ToList();
            temp.position = (from i in context.Positions where i.NamePosition != "" select i.NamePosition).ToList();
            temp.user = (from i in context.Users where i.SecondName != "" select i.SecondName).ToList();
            temp.company = (from i in context.Companies where i.NameCompany != "" select i.NameCompany).ToList(); 
            temp.sensor = (from i in context.Sensors where i.NameSensor != "" select i.NameSensor).ToList(); 
            temp.visit = (from i in context.Visits where i.VisitId != 0 select i.VisitId.ToString()).ToList();

        }
        public IActionResult Main()
        {
            return View(temp);
        }
        
    }
}
