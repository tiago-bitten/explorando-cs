using EeFee.DTOs;
using EeFee.Models;

namespace EeFee.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateAsync(CreateUserDTO dto);
        Task DeleteAsync(User user);
        Task UpdateAsync(User user);
        Task<User> FindByIdAsync(int id);
        Task<User> FindByUsernameAsync(string username);
    }
}
