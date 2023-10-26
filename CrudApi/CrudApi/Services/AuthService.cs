using CrudApi.DTOs;
using CrudApi.Repositories.Interfaces;
using CrudApi.Services.Interfaces;

namespace CrudApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;

        public AuthService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<TokenDto> LoginAsync(AuthDto dto)
        {
            var user = await _userService.FindByUsername(dto.Username);
            if (user == null)
            {
                throw new Exception("Username not valid");
            }

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);
            if (!isValidPassword)
            {
                throw new Exception("Password is wrong");
            }

            return new TokenDto
            {
                Token = "lfjasdlafsdt78as6asfdhofasd.r32yyewrfsd.rewhihsfdlksaf"
            };
        }
    }
}
