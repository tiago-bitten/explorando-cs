using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DemoTypingTest.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string ProfileImageURL { get; set; }
        public virtual ICollection<Test> Tests { get; set; }

        public ApplicationUser() : base()
        {
        }
    }
}
