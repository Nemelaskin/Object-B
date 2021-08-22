
namespace Object_B.Models
{
    public class Sensor
    {
        public int SensorId { get; set; }
        public string NameSensor { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

    }
}
