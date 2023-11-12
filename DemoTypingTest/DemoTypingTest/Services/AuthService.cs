using AutoMapper;
using DemoTypingTest.Data.Dtos;
using DemoTypingTest.Models;
using Microsoft.AspNetCore.Identity;

namespace DemoTypingTest.Services
{
    public class AuthService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly TokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthService(SignInManager<ApplicationUser> signInManager,
            TokenService tokenService, IMapper mapper)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<TokenDto> Login(SignInDto dto)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);
        
            if (!result.Succeeded)
            {
                throw new ApplicationException("Invalid login attempt.");
            }

            ApplicationUser user = await _signInManager.UserManager.FindByNameAsync(dto.Username);

            return new TokenDto
            {
                User = _mapper.Map<ReadApplicationUserDto>(user),
                Token = _tokenService.GenerateToken(user)
            };
        }
    }
}
