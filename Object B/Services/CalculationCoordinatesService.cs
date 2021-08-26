using Object_B.Models;
using Object_B.Models.Context;
using System;
using System.Linq;

namespace Object_B.Services
{
    public class CalculationCoordinatesService
    {
        private readonly AllDataContext context;

        public CalculationCoordinatesService(AllDataContext context)
        {
            this.context = context;
        }

         public Square[] NumberToCoordinates(int id)
        {
            int count = 52;
            Room room =  context.Rooms.Find(id);
            try
            {
                int[] coords = room.CoordinatesRoom.Split(' ').Select(u => Convert.ToInt32(u)).ToArray();
                Square[] array = new Square[coords.Length];
                
                for(int i = 0; i < coords.Length; i++)
                {
                    array[i] = new Square();
                    array[i].X = coords[i] % count;
                    array[i].Y = coords[i] / count;
                }
                return array;
            }
            catch(Exception e) { return null; }



        }
        public class Square
        {
            public Square()
            {
                X = 0;
                Y = 0;
            }
            public int X{ get; set; }
            public int Y{ get; set; }
        }
    }
}
