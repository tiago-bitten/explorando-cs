using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoTypingTest.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Column("profile_image_url")]
        public string ProfileImageURL { get; set; }
        public virtual ICollection<Test> Tests { get; set; }

        public ApplicationUser() : base()
        {
        }
    }
}
