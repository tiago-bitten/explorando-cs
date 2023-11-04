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
            var existsPosition = await _positionRepository.FindByName(dto.Name);
            if (existsPosition != null)
            {
                throw new Exception("Position already exists");
            }

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

        public async Task<PositionDTO> FindByIdAsync(int id)
        {
            var position = await _positionRepository.FindByIdAsync(id);
            if (position == null)
            {
                throw new Exception("Position was not found");
            }

            return _mapper.Map<PositionDTO>(position);
        }

        public Task UpdateAsync(PositionDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<PositionDTO> FindByName(string name)
        {
            return _mapper.Map<PositionDTO>(await _positionRepository.FindByName(name));
        }
    }
}
