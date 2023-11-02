using System.ComponentModel.DataAnnotations;

namespace EeFee.DTOs
{
    public class CreatePositionDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
