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
            User existsUser = await _userRepository.GetUserByUsernameAsync(dto.Username);
            if (existsUser != null)
            {
                throw new Exception("Username already exists");
            }

            User user = _mapper.Map<User>(dto);
            user.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            _userRepository.CreateAsync(user);

            return _mapper.Map<UserDto>(user);
        }

        public Task<UserDto> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByUsername(string username)
        {
            return _userRepository.GetUserByUsernameAsync(username);
        }

        public Task<UserDto> Update(int id, UserDto dto)
        {
            var userToUpdate = _userRepository.GetByIdAsync(id);
            if (userToUpdate == null)
            {
                throw new Exception("User not found");
            }

        }
    }
}
