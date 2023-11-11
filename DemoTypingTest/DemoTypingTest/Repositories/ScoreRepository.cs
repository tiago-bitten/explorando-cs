using DemoTypingTest.Data;
using DemoTypingTest.Models;

namespace DemoTypingTest.Repositories
{
    public class ScoreRepository
    {
        private readonly IdentityUserDbContext _context;

        public ScoreRepository(IdentityUserDbContext context)
        {
            _context = context;
        }

        public async Task Create(Score score)
        {
            await _context.Scores.AddAsync(score);
            await _context.SaveChangesAsync();
        }
    }
}
