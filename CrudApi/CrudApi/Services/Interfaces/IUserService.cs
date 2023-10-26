﻿using CrudApi.DTOs;
using CrudApi.Models;

namespace CrudApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> Create(CreateUserDto dto);
        UserDto Update(UpdateUserDto dto);
        void Delete(int id);
        IEnumerable<UserDto> GetAll();
        UserDto FindById(int id);
        UserDto FindByUsername(string username);
    }
}
