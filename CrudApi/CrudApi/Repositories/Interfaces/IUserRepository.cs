using CrudApi.DTOs;
using CrudApi.Models;

namespace CrudApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        void CreateAsync(User user);
        void UpdateAsync(User dto);
        void DeleteAsync(int id);
        Task<User> GetUserByUsernameAsync(string username);
    }
}
