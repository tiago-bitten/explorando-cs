using AutoMapper;
using EeFee.DTOs;
using EeFee.Models;
using EeFee.Repositories.Interfaces;
using EeFee.Services.Interfaces;

namespace EeFee.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IPositionService positionService, IMapper mapper)
        {
            _userRepository = userRepository;
            _positionService = positionService;
            _mapper = mapper;
        }

        public async Task<UserDTO> CreateAsync(CreateUserDTO dto)
        {
            var userDTO = await FindByUsernameAsync(dto.Username);
            if (userDTO != null)
            {
                throw new Exception("User already exists");
            }

            var positionDTO = await _positionService.FindByIdAsync(dto.PositionId);

            dto.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var user = _mapper.Map<User>(dto);
            var position = _mapper.Map<Position>(positionDTO);

            user.PositionId = position.Id;

            await _userRepository.CreateAsync(user);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            _userRepository.DeleteAsync(user);
        }

        public async Task<IEnumerable<UserDTO>> FindAllAsync(int skip, int take)
        {
            var users = await _userRepository.FindAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users.Skip(skip).Take(take));
        }

        public async Task<UserDTO> FindByIdAsync(int id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> FindByUsernameAsync(string username)
        {
            return _mapper.Map<UserDTO>(await _userRepository.FindByUsernameAsync(username));
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
