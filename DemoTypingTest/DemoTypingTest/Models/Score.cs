using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoTypingTest.Models
{
    [Table("tb_score")]
    public class Score
    {
        [Key]
        [Required]
        [Column("id")]
        public string Id { get; set; }

        [Required]
        [Column("wpm")]
        public double Wpm { get; set; }

        [Required]
        [Column("accuracy")]
        public double Accuracy { get; set; }

        [Required]
        [Column("test_id")]
        [ForeignKey("Test")]
        public string TestId { get; set; }

        public virtual Test Test { get; set; }
    }
}
