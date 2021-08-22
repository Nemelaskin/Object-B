using Object_B.Models;
using Object_B.Models.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Object_B.Services
{
    public class CalculationCoordinates
    {
        private readonly AllDataContext context;

        public CalculationCoordinates(AllDataContext context)
        {
            this.context = context;
        }

        async public Task<Square[]> NumberToCoordinates(int id)
        {
            int count = 52;
            Room room = await context.Rooms.FindAsync(id);
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
