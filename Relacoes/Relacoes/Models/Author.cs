using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Relacoes.Models
{
    public class Author
    {
        [Key]
        [Required]
        private int Id { get; set; }
        
        [Required]
        private string Name { get; set; }
        
        [Required]
        [EmailAddress]
        [Unicode]
        private string Email { get; set; }
    }
}
