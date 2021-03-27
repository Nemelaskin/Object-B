using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Object_B.Models
{
    public class AdminViewModel
    {
        public List<string> role { get; set; } = new List<string>();
        public List<string> room { get; set; } = new List<string>();
        public List<string> sensor { get; set; } = new List<string>();
        public List<string> user { get; set; } = new List<string>();
        public List<string> visit { get; set; } = new List<string>();
        public List<string> company { get; set; } = new List<string>();
        public List<string> position { get; set; } = new List<string>();
    }
}
