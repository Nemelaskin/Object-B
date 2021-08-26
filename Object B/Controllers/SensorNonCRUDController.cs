using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Object_B.Models;
using Object_B.Models.Context;
using Object_B.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Object_B.Services.CalculationCoordinatesService;

namespace Object_B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorNonCRUDController : ControllerBase
    {
        AllDataContext context;
        ConvertRoomsService ConvertRoomsService;
        public SensorNonCRUDController(AllDataContext context)
        {
            this.context = context;
            ConvertRoomsService = new ConvertRoomsService(context);
        }

        [HttpGet("TakeUserForSensor")]
        async public Task<IActionResult> TakeUserForSensor()
        {
            var user = await TakeUser();
            return Ok(user.UserId);
        }

        
        [HttpGet("GetCoordinates")]
        public ActionResult GetCoordinates()
        {
            List<Square[]> container = ConvertRoomsService.CalculationCoordinates();
            return Ok(container);
        }
        
        async private Task<User> TakeUser()
        {
            var users = context.Users.ToList();
            User user = new User();
            foreach (var i in users)
            {
                if (i.IsActive == false)
                {
                    user = i;
                    user.IsActive = true;
                    context.Entry(user).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    break;
                }
            }
            return user;
        }
    }
}
