using CrudApi.DTOs;
using CrudApi.Models;

namespace CrudApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task Create(User user);
        Task<IEnumerable<User>> FindAll();
        Task<User> FindById(int id);
        void Update(User user, int id);
        void Delete(User user);
        Task<User> FindByUsername(string username);
    }
}
