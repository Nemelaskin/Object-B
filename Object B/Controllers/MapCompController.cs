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
        public IActionResult CreateMap(string selectCom = "", string selectRoom = "")
        {
            if (selectRoom == "")
            {
                var s = context.Rooms.Where(u => u.RoomId == 1).Select(u => new { u.NameRoom, u.RoomId }).First();
                ViewBag.SelectRoomName = s.NameRoom;
                ViewBag.SelectRoomId = s.RoomId;
            }
            else
            {
                var s = context.Rooms.Where(u => u.NameRoom == selectRoom).Select(u => new { u.NameRoom, u.RoomId }).First();
                ViewBag.SelectRoomName = s.NameRoom;
                ViewBag.SelectRoomId = s.RoomId;
            }

            if (selectCom == "")
            {
                ViewBag.SelectCom = context.Companies.Where(u => u.CompanyId == 1).Select(u => u.NameCompany).First();
                ViewBag.Rooms = context.Rooms.Where(u => u.Company.CompanyId == 1).Select(u => u.NameRoom);
            }
            else
            {
                ViewBag.SelectCom = context.Companies.Where(u => u.NameCompany == selectCom).Select(u => u.NameCompany).First();
                ViewBag.Rooms = context.Rooms.Where(u => u.Company.NameCompany == selectCom).Select(u => u.NameRoom);
            }
            ViewBag.Companies = context.Companies.Select(u => u.NameCompany);
            return View();
        }


        [HttpGet]
        public string CreateRoom(int selectRoomId, string newRoom = "")
        {
            Console.WriteLine(newRoom);
            if (newRoom != null)
            {
                var _y = context.Rooms.Find(selectRoomId);
                _y.CoordinatesRoom = newRoom;
                context.SaveChanges();
            }
            var temp = (IEnumerable<Room>)context.Rooms.Include(u => u.Company);
            foreach (var i in temp)
            {
                i.Company.Room = null;
            }
            var t = JsonConvert.SerializeObject(temp);
            return t;
        }
        
    }
}
