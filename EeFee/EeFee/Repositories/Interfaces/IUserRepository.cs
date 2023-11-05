using EeFee.Models;

namespace EeFee.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);
        void DeleteAsync(User user);
        Task UpdateAsync(User user);
        Task<User> FindByIdAsync(int id);
        Task<IEnumerable<User>> FindAllAsync();
        Task<User> FindByUsernameAsync(string username);
        Task<IEnumerable<User>> FindByPosition(int positionId);
    }
}
