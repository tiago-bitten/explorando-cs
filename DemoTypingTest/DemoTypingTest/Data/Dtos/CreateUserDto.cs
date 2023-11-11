using System.ComponentModel.DataAnnotations;

namespace DemoTypingTest.Data.Dtos
{
    public class CreateUserDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
