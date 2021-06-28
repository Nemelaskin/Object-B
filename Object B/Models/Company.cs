using System.Collections.Generic;

namespace Object_B.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string MapLink { get; set; }
        public string NameCompany { get; set; }
        public List<Room> Room { get; set; } = new List<Room>();
        public string Owner { get; set; }


    }
}
