using DemoTypingTest.Data.Dtos;
using DemoTypingTest.Models;
using Microsoft.AspNetCore.Identity;

namespace DemoTypingTest.Services
{
    public class AuthService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly TokenService _tokenService;

        public AuthService(SignInManager<ApplicationUser> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<TokenDto> Login(LoginDto dto)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);
        
            if (!result.Succeeded)
            {
                throw new ApplicationException("Invalid login attempt.");
            }

            ApplicationUser user = await _signInManager.UserManager.FindByNameAsync(dto.Username);

            return new TokenDto
            {
                Token = _tokenService.GenerateToken(user)
            };
        }
    }
}
