using AutoMapper;
using DemoTypingTest.Data.Dtos;
using DemoTypingTest.Exceptions;
using DemoTypingTest.Models;
using DemoTypingTest.Utils;
using Microsoft.AspNetCore.Identity;

namespace DemoTypingTest.Services
{
    public class AuthService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthService(SignInManager<ApplicationUser> signInManager,
           UserManager<ApplicationUser> userManager ,TokenService tokenService, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<TokenDto> SignIn(SignInDto dto)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password,
                false, false);
        
            if (!result.Succeeded)
            {
                throw new ValidationException("Invalid login attempt.");
            }

            ApplicationUser user = await _signInManager.UserManager.FindByNameAsync(dto.Username);

            return new TokenDto
            {
                User = _mapper.Map<ReadApplicationUserDto>(user),
                Token = _tokenService.GenerateToken(user)
            };
        }

        public async Task<ReadApplicationUserDto> SignUp(CreateUserDto dto)
        {
            ApplicationUser user = _mapper.Map<ApplicationUser>(dto);
            user.ProfileImageKey = GoogleDriveService.DEFAULT_PROFILE_IMAGE_KEY;

            IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                throw new ValidationException(result.Errors.First().Description);
            }

            return _mapper.Map<ReadApplicationUserDto>(user);
        }
    }
}
