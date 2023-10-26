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

        public async Task Create(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<User>> FindAll()
        {
            return await _context.Users.ToListAsync();
        }

        public User FindById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public void Update(User user, int id)
        {
            var userToUpdate = FindById(id);
            _context.Entry(userToUpdate).CurrentValues.SetValues(user);
            _context.SaveChanges();
        }

        public User FindByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }
    }
}
