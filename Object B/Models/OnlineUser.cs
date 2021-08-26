using System;
using System.ComponentModel.DataAnnotations;

namespace Object_B.Models
{
    public class OnlineUser
    {
        public int UserId { get; set; }
        [Key]
        public string ConnectionId { get; set; }
        public DateTime time { get; set; }
    }
}
