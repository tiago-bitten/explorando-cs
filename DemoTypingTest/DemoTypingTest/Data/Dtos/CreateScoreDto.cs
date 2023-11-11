using System.ComponentModel.DataAnnotations;

namespace DemoTypingTest.Data.Dtos
{
    public class CreateScoreDto
    {
        [Required]
        public double Wpm { get; set; }

        [Required]
        public double Accuracy { get; set; }

        [Required]
        public string TestId { get; set; }
    }
}
