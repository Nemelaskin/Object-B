using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Object_B.Models
{
    public class Sensor
    {
        public int SensorId { get; set; }
        public string NameSensor { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string Coordinates { get; set; }

    }
}
