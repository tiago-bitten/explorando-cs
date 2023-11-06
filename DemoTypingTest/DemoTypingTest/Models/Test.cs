using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoTypingTest.Models
{
    [Table("tb_test")]
    public class Test
    {
        [Key]
        [Required]
        [Column("id")]
        public string Id { get; set; }

        [Required]
        [Column("text_test")]
        public string TextTest { get; set; }

        [Required]
        [Column("total_words")]
        public int TotalWords { get; set; }

        [Required]
        [Column("total_characters")]
        public int TotalCharacters { get; set; }

        [Required]
        [Column("incorrect_words")]
        public int IncorrectWords { get; set; }

        [Required]
        [Column("incorrect_characters")]
        public int IncorrectCharacters { get; set; }

        [Required]
        [Column("time")]
        public int Time { get; set; }

        [Required]
        [Column("user_id")]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
