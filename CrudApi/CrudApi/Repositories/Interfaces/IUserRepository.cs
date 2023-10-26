﻿using CrudApi.DTOs;
using CrudApi.Models;

namespace CrudApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task Create(User user);
        IEnumerable<User> FindAll();
        User FindById(int id);
        void Update(User user, int id);
        void Delete(User user);
        User FindByUsername(string username);
    }
}
