using AutoMapper;
using DemoTypingTest.Data;
using DemoTypingTest.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoTypingTest.Repositories
{
    public class ScoreRepository
    {
        private readonly IdentityUserDbContext _context;
        private readonly IMapper _mapper;

        public ScoreRepository(IdentityUserDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(Score score)
        {
            await _context.Scores.AddAsync(score);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Score>> GetAllUserScore(string userId)
        {
            return await _context.Scores
                .Include(score => score.Test)
                .Include(score => score.Test.User)
                .Where(score => score.Test.UserId == userId)
                .OrderByDescending(score => score.Wpm - score.Test.Time)
                .ToListAsync();
        }

        public async Task<ICollection<Score>> GetUserBestScores(string userId, string difficulty)
        {
            return await _context.Scores
                .Include(score => score.Test)
                .Include(score => score.Test.User)
                .Where(score => score.Test.UserId == userId && score.Test.Difficulty == difficulty)
                .OrderByDescending(score => score.Wpm - score.Test.Time)
                .ToListAsync();
        }

        public async Task<ICollection<Score>> GetTopScores(string difficulty)
        {
            return await _context.Scores
                .Include (score => score.Test)
                .Include(score => score.Test.User)
                .Where(score => score.Test.Difficulty == difficulty)
                .OrderByDescending(score => score.Wpm - score.Test.Time)
                .ToListAsync();
        }
    }
}
