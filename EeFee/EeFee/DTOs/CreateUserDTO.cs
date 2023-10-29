using System.ComponentModel.DataAnnotations;

namespace EeFee.DTOs
{
    public class CreateUserDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
