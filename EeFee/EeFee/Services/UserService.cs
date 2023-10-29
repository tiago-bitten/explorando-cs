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
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateUserDTO dto)
        {
            var user = _mapper.Map<User>(dto);
            await _userRepository.CreateAsync(user);
        }

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
