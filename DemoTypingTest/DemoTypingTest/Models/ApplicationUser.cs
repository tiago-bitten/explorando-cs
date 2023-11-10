using Microsoft.AspNetCore.Identity;

namespace DemoTypingTest.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public override int Id { get; set; }
        public string ProfileImageURL { get; set; }
        public virtual IEnumerable<Test> Tests { get; set; }

        public ApplicationUser() : base()
        {
        }
    }
}
