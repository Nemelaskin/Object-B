using System;

namespace Object_B.Models
{
    public class Visit
    {
        public int VisitId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime VisitTime { get; set; }
        public Room Room { get; set; }
        public int RoomId { get; set; }
    }
}
