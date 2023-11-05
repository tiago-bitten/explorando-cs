using System.ComponentModel.DataAnnotations;

namespace DemoIndentity.Data.Dtos
{
    public class CreateUserDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
