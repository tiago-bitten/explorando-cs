﻿using AutoMapper;
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

        public async Task<UserDto> CreateAsync(User user)
        {

        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            return _mapper.Map<List<UserDto>>(await _context.Users.ToListAsync());
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            return _mapper.Map<UserDto>(await _context.Users.FindAsync(id));
        }

        public async Task<UserDto> UpdateAsync(int id, UserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            var userToUpdate = await GetByIdAsync(id);
            if (userToUpdate == null)
            {
                throw new Exception("User not found");
            }

            userToUpdate.Username = user.Username;
            userToUpdate.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            _context.SaveChanges();
            return _mapper.Map<UserDto>(userToUpdate);
        }
        public async Task<UserDto> DeleteAsync(int id)
        {
            var userToDelete = await _context.Users.FindAsync(id);

            if (userToDelete == null)
            {
                throw new Exception("User not found");
            }

            _context.Users.Remove(userToDelete);
            _context.SaveChanges();

            return _mapper.Map<UserDto>(userToDelete);
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
