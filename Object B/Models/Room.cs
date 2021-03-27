using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Object_B.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string NameRoom { get; set; }
        public Company Company { get; set; }
        public string CoordinatesRoom { get; set; }

    }
}
