using Microsoft.AspNetCore.Identity;

namespace DemoTypingTest.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string ProfileImageURL { get; set; }
        public virtual IEnumerable<Test> Tests { get; set; }

        public ApplicationUser() : base()
        {
        }
    }
}
