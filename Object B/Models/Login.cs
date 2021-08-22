using System.ComponentModel.DataAnnotations;

namespace Object_B.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        
    }
}
