using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EeFee.Models
{
    [Table("tb_position")]
    public class Position
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
