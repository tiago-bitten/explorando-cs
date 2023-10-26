using CrudApi.DTOs;
using CrudApi.Repositories.Interfaces;
using CrudApi.Services.Interfaces;

namespace CrudApi.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}
