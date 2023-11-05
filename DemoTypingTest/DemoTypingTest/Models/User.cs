using Microsoft.AspNetCore.Identity;

namespace DemoTypingTest.Models
{
    public class User : IdentityUser
    {
        public string ProfileImageURL { get; set; }

        public User() : base()
        {
        }
    }
}
