using CrudApi.DTOs;
using CrudApi.Models;

namespace CrudApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> Create(CreateUserDto dto);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> GetById(int id);
        Task<UserDto> Update(int id, UserDto dto);
        Task<UserDto> Delete(int id);
        Task<User> GetUserByUsername(string username);
    }
}
