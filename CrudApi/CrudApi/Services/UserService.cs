using AutoMapper;
using CrudApi.DTOs;
using CrudApi.Models;
using CrudApi.Repositories.Interfaces;
using CrudApi.Services.Interfaces;

namespace CrudApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Create(CreateUserDto dto)
        {
            var existingUser = await _userRepository.FindByUsername(dto.Username);
            if (existingUser != null)
            {
                throw new Exception("Username already exists");
            }

            var user = _mapper.Map<User>(dto);
            user.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            await _userRepository.Create(user);

            return _mapper.Map<UserDto>(user);
        }

        public async Task Delete(int id)
        {
            var user = await _userRepository.FindById(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            await _userRepository.Delete(user);
        }

        public async Task<UserDto> FindById(int id)
        {
            var user = await _userRepository.FindById(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> FindAll(int skip, int take)
        {
            var users = await _userRepository.FindAll();
            return _mapper.Map<IEnumerable<UserDto>>(users.Skip(skip).Take(take));
        }

        public async Task Update(UpdateUserDto dto, int id)
        {
            var user = _mapper.Map<User>(dto);
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            await _userRepository.Update(user, id);
        }

        public async Task<UserDto> FindByUsername(string username)
        {
            var user = await _userRepository.FindByUsername(username);
            return _mapper.Map<UserDto>(user);
        }
    }
}
