using EeFee.Models;

namespace EeFee.Repositories.Interfaces
{
    public interface IPositionRepository
    {
        Task CreateAsync(Position position);
        void Delete(Position position);
        Task UpdateAsync(Position position);
        Task<Position> FindByIdAsync(int id);
        Task<IEnumerable<Position>> FindAllAsync();
    }
}
