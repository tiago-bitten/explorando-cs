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
            var existsUser = _userRepository.FindByUsername(dto.Username);
            if (existsUser != null)
            {
                throw new Exception("User already exists");
            }

            var user = _mapper.Map<User>(dto);

            await _userRepository.Create(user);
            return _mapper.Map<UserDto>(user);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserDto FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserDto Update(UpdateUserDto dto)
        {
            throw new NotImplementedException();
        }

        public UserDto FindByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
