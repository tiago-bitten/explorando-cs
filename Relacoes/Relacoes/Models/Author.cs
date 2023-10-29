using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Relacoes.Models
{
    public class Author
    {
        [Key]
        private int Id { get; set; }

        [Required]
        private string Name { get; set; }

        [Required]
        [EmailAddress]
        private string Email { get; set; }
    }
}
