using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Object_B.Services;
using Object_B.Models.Context;
using static Object_B.Services.CalculationCoordinates;
using Object_B.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Object_B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationCoordinatesController : ControllerBase
    {
        AllDataContext context;
        public CalculationCoordinatesController(AllDataContext context)
        {
            this.context = context;
        }

        [HttpGet("GetCoordinates")]
        async public Task<ActionResult> GetCoordinates()
        {
            CalculationCoordinates CC = new CalculationCoordinates(context);
            Room[] rooms = context.Rooms.ToArray();
            List<Square[]> container = new List<Square[]>();
            for (int i = 0; i < rooms.Length; i++)
            {
                Square[] tempArray = await CC.NumberToCoordinates(rooms[i].RoomId);
                container.Add(tempArray);
            }
            return Ok(container);
        }
    }
}
