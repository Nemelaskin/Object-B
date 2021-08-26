using Object_B.Models;
using Object_B.Models.Context;
using System;
using System.Linq;
using static Object_B.Services.CalculationCoordinatesService;

namespace Object_B.Services
{
    public class CreateVisitService
    {
        AllDataContext context;
        SingltonService singlton;
        public CreateVisitService(AllDataContext context, SingltonService singlton)
        {
            this.context = context;
            this.singlton = singlton;
        }

        public void CreateVisits(string connectionId, string coordinates, string user)
        {
            
            Square coords = new Square();
            var temp = coordinates.Split(':');
            coords.X = Convert.ToInt32(temp[0]);
            coords.Y = Convert.ToInt32(temp[1]);
            var rooms = singlton.rooms;
            var roomsDB = context.Rooms.ToList();

            if (singlton.dictionaryCoords.ContainsKey(connectionId))
            {
                Room lastRoom = new Room();
                Room currentRoom = new Room();
                for(int i =0; i < rooms.Count; i++)
                {
                    for(int j = 0; j < rooms[i].Length; j++)
                    {
                        if(singlton.dictionaryCoords[connectionId].X == rooms[i][j].X && singlton.dictionaryCoords[connectionId].Y == rooms[i][j].Y)
                        {
                            lastRoom = roomsDB[i];
                        }
                        if (coords.X == rooms[i][j].X && coords.Y == rooms[i][j].Y)
                        {
                            currentRoom = roomsDB[i];
                        }
                    }
                }
                if(lastRoom.RoomId != currentRoom.RoomId)
                {
                    Visit visit = new Visit();
                    visit.RoomId = currentRoom.RoomId;
                    visit.UserId = Convert.ToInt32(user);
                    visit.VisitTime = DateTime.Now;
                    context.Visits.Add(visit);
                    context.SaveChanges();
                }
            }
            if (singlton.dictionaryCoords.ContainsKey(connectionId))
            {
                singlton.dictionaryCoords[connectionId] = coords;
            }
            else
            {
                singlton.dictionaryCoords.Add(connectionId, coords);
            }
        }
    }
}
