using EeFee.Models;

namespace EeFee.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);
        Task DeleteAsync(User user);
        Task UpdateAsync(User user);
        Task<User> FindByIdAsync(int id);
        Task<User> FindByUsernameAsync(string username);
    }
}
