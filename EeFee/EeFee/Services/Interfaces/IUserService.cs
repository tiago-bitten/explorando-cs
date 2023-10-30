using EeFee.DTOs;
using EeFee.Models;

namespace EeFee.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> CreateAsync(CreateUserDTO dto);
        Task DeleteAsync(User user);
        Task UpdateAsync(User user);
        Task<UserDTO> FindByIdAsync(int id);
        Task<UserDTO> FindByUsernameAsync(string username);
    }
}
