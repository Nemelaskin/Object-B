using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Object_B.Models.Context;
using Object_B.Models;
using Microsoft.AspNetCore.Authorization;

namespace Object_B.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class MapCompController : ControllerBase
    {
        AllDataContext context;
        public MapCompController(AllDataContext context)
        {
            this.context = context;
        }

        [HttpGet("CreateRoom")]
        public string CreateRoom(int selectRoomId, string newRoom = "")
        {
            Console.WriteLine(newRoom);
            if (newRoom != null)
            {
                var room = context.Rooms.Find(selectRoomId);
                room.CoordinatesRoom = newRoom;
                context.SaveChanges();
            }
            var temp = (IEnumerable<Room>)context.Rooms.Include(u => u.Company);
            foreach (var i in temp)
            {
                i.Company.Room = null;
            }
            var response = JsonConvert.SerializeObject(temp);
            return response;
        }
        
    }
}
