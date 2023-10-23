using CrudApi.Data;
using CrudApi.Models;
using CrudApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly CrudApiContext _context;

        public UserRepository(CrudApiContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> UpdateAsync(User user)
        {
            var userToUpdate = await GetByIdAsync(user.Id);

            if (userToUpdate == null)
            {
                throw new Exception("User not found");
            }

            userToUpdate.Username = user.Username;
            userToUpdate.Password = user.Password;

            _context.Users.Update(userToUpdate);
            _context.SaveChanges();

            return userToUpdate;
        }
        public async Task<User> DeleteAsync(int id)
        {
            var userToDelete = await GetByIdAsync(id);

            if (userToDelete == null)
            {
                throw new Exception("User not found");
            }

            _context.Users.Remove(userToDelete);
            _context.SaveChanges();

            return userToDelete;
        }
    }
}
