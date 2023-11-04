using AutoMapper;
using EeFee.DTOs;
using EeFee.Models;
using EeFee.Repositories.Interfaces;
using EeFee.Services.Interfaces;

namespace EeFee.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;

        public PositionService(IPositionRepository positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

        public async Task<PositionDTO> CreateAsync(CreatePositionDTO dto)
        {
            var position = _mapper.Map<Position>(dto);
            await _positionRepository.CreateAsync(position);

            return _mapper.Map<PositionDTO>(position);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PositionDTO>> FindAllAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<PositionDTO> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PositionDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
