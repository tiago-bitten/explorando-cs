using EeFee.Data;
using EeFee.Models;
using EeFee.Repositories.Interfaces;
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

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
