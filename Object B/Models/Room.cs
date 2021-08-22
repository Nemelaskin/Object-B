
namespace Object_B.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string NameRoom { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public string CoordinatesRoom { get; set; }
        public bool IsACoridor { get; set; }

    }
}
