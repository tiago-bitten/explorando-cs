using DemoTypingTest.Data;
using DemoTypingTest.Models;

namespace DemoTypingTest.Repositories
{
    public class TestRepository
    {
        private readonly IdentityUserDbContext _context;

        public TestRepository(IdentityUserDbContext context)
        {
            _context = context;
        }

        public async Task Create(Test test)
        {
            await _context.Tests.AddAsync(test);
            await _context.SaveChangesAsync();
        }

        public async Task<Test> FindById(string id)
        {
            return await _context.Tests.FindAsync(id);
        }
    }
}
