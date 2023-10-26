using CrudApi.DTOs;
using CrudApi.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CrudApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> Create(CreateUserDto dto);
        UserDto Update(UpdateUserDto dto);
        void Delete(int id);
        Task<IEnumerable<UserDto>> FindAll(int skip, int take);
        Task<UserDto> FindById(int id);
        UserDto FindByUsername(string username);
    }
}
