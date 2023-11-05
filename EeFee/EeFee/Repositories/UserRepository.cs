using EeFee.Data;
using EeFee.Models;
using EeFee.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace EeFee.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EeFeeContext _context;

        public UserRepository(EeFeeContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public void DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> FindAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> FindByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> FindByPosition(int positionId)
        {
            return await _context.Users.Where(u => u.PositionId == positionId).ToListAsync();
        }
    }
}
