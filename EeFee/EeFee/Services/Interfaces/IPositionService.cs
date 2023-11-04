using EeFee.DTOs;

namespace EeFee.Services.Interfaces
{
    public interface IPositionService
    {
        Task<PositionDTO> CreateAsync(CreatePositionDTO dto);
        Task DeleteAsync(int id);
        Task UpdateAsync(PositionDTO dto);
        Task<PositionDTO> FindByIdAsync(int id);
        Task<IEnumerable<PositionDTO>> FindAllAsync(int skip, int take);
    }
}
