using AutoMapper;
using DemoIndentity.Data.Dtos;
using DemoIndentity.Models;
using Microsoft.AspNetCore.Identity;

namespace DemoIndentity.Services
{
    public class UserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly TokenService _tokenService;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<User> Create(CreateUserDto dto)
        {
            User user = _mapper.Map<User>(dto);
            user.DateOfBirth = user.DateOfBirth.ToUniversalTime();

            IdentityResult result = await _userManager.CreateAsync(user, dto.Password);
            
            if (!result.Succeeded)
            {
                throw new ApplicationException(result.Errors.First().Description);
            }

            return user;
        }

        public async Task<string> Login(LoginDto dto)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);
            
            if (!result.Succeeded)
            {
                throw new ApplicationException("Invalid login attempt");
            }

            var user = _signInManager.UserManager.Users.FirstOrDefault(u => u.UserName == dto.Username);

            return _tokenService.GenerateToken(user);
        }
    }
}
