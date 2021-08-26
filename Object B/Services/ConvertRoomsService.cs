using Object_B.Models;
using Object_B.Models.Context;
using System.Collections.Generic;
using System.Linq;
using static Object_B.Services.CalculationCoordinatesService;

namespace Object_B.Services
{
    public class ConvertRoomsService
    {
        AllDataContext context;
        public ConvertRoomsService(AllDataContext context)
        {
            this.context = context;
        }

        public  List<Square[]> CalculationCoordinates()
        {
            CalculationCoordinatesService CC = new CalculationCoordinatesService(context);
            Room[] rooms = context.Rooms.ToArray();
            List<Square[]> container = new List<Square[]>();
            for (int i = 0; i < rooms.Length; i++)
            {
                Square[] tempArray =  CC.NumberToCoordinates(rooms[i].RoomId);
                container.Add(tempArray);
            }

            return container;
        }
    }
}
