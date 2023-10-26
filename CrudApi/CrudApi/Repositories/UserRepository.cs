using AutoMapper;
using CrudApi.Data;
using CrudApi.DTOs;
using CrudApi.Models;
using CrudApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly CrudApiContext _context;
        private readonly IMapper _mapper;

        public UserRepository(CrudApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateAsync(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public void UpdateAsync(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
        public async void DeleteAsync(int id)
        {
            var userToDelete = await _context.Users.FindAsync(id);

            if (userToDelete == null)
            {
                throw new Exception("User not found");
            }

            _context.Users.Remove(userToDelete);
            _context.SaveChanges();
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
