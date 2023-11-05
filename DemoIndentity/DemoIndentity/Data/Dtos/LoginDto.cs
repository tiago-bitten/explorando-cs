using System.ComponentModel.DataAnnotations;

namespace DemoIndentity.Data.Dtos
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }

        [Required] 
        public string Password { get; set; }
    }
}
