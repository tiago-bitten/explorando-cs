using Microsoft.AspNetCore.Identity;

namespace DemoIndentity.Models
{
    public class User : IdentityUser
    {
        public DateTime DateOfBirth { get; set; }

        public User() : base()
        {
            
        }
    }
}
