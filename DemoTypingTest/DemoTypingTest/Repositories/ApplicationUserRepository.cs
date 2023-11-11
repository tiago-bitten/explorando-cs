using DemoTypingTest.Data;
using DemoTypingTest.Models;

namespace DemoTypingTest.Repositories
{
    public class ApplicationUserRepository
    {
        private readonly IdentityUserDbContext _context;

        public ApplicationUserRepository(IdentityUserDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> FindById(string id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
