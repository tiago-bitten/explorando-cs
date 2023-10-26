using System.ComponentModel.DataAnnotations;

namespace CrudApi.DTOs
{
    public class AuthDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
