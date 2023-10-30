using System.ComponentModel.DataAnnotations.Schema;

namespace EeFee.Models
{
    [Table("tb_position")]
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
