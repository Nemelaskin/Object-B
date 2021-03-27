using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Object_B.Models
{
    public class Visit
    {
        public int VisitId { get; set; }
        public User User { get; set; }
        public DateTime VisitTime { get; set; }
        public Room Room { get; set; }

    }
}
