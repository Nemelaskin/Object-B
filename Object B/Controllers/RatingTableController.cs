using Microsoft.AspNetCore.Mvc;
using Object_B.Models;
using Object_B.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Object_B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingTableController : ControllerBase
    {
        AllDataContext context;
        public RatingTableController( AllDataContext context)
        {
            this.context = context;
        }
        
        [HttpGet]
        [Route ("index")]
        
        public List<RatingTable> Rating()
        {
            var users = context.Users.ToList();
            var visits = context.Visits.ToList();

            CompareUsers CompUsers = new CompareUsers();
            List<RatingTable> ratTable = new List<RatingTable>();

            //var month = DateTime.Now.Month;
            //DateTime.DaysInMonth(2021, month);

            for (int j = 0; j < users.Count(); j++)
            {
                int count = 0;
                string Name = "";
                string SurName = "";
                string Email = "";
                for (int i = 0; i < visits.Count(); i++)
                {
                    Name = users[j].FirstName;
                    SurName = users[j].SecondName;
                    Email = users[j].Email;
                    if (users[j].UserId == visits[i].UserId)
                    {
                        count++;
                    }
                }
                RatingTable ratingTable = new RatingTable();
                ratingTable.Position = count;
                ratingTable.Name = Name;
                ratingTable.SurName = SurName;
                ratingTable.Email = Email;
                ratTable.Add(ratingTable);
            }
            ratTable.Sort(CompUsers);

            //ViewBag.ratTab = ratTable;
            return ratTable;
        }
    }
}
