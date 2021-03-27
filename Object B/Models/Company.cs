using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Object_B.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string MapLink { get; set; }
        public string NameCompany { get; set; }
        public List<Room> Room { get; set; } = new List<Room>();
        public User Owner { get; set; }

    }
}
