using CrudApi.DTOs;
using CrudApi.Models;

namespace CrudApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(int id);
        Task<UserDto> CreateAsync(User user);
        Task<UserDto> UpdateAsync(int id, UserDto dto);
        Task<UserDto> DeleteAsync(int id);
        Task<User> GetByUsernameAsync(string username);
    }
}
