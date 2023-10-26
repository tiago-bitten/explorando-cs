using CrudApi.DTOs;
using CrudApi.Models;

namespace CrudApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task Create(User user);
        Task<IEnumerable<User>> FindAll();
        Task<User> FindById(int id);
        Task Update(User user, int id);
        Task Delete(User user);
        Task<User> FindByUsername(string username);
    }
}
