using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EeFee.Models
{
    [Table("tb_user")]
    public class User
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("username")]
        public string Username { get; set; }

        [Required]
        [Column("password")]
        public string Password { get; set; }

        [ForeignKey("Position")]
        [Column("position_id")]
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
    }
}
