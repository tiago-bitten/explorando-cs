using System.ComponentModel.DataAnnotations;

namespace DemoTypingTest.Data.Dtos
{
    public class CreateTestDto
    {
        [Required]
        public string TextTest { get; set; }

        [Required]
        public int TotalWords { get; set; }

        [Required]
        public int TotalCharacters { get; set; }

        [Required]
        public int IncorrectWords { get; set; }

        [Required]
        public int IncorrectCharacters { get; set; }

        [Required]
        public int Time { get; set; }

        [Required]
        public string Difficulty { get; set; }
    }
}