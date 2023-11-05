using AutoMapper;
using DemoTypingTest.Data.Dtos;
using DemoTypingTest.Models;
using Microsoft.AspNetCore.Identity;

namespace DemoTypingTest.Services
{
    public class UserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserService(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<ReadUserDto> Create(CreateUserDto dto)
        {
            User user = _mapper.Map<User>(dto);
            user.ProfileImageURL = "default-profile-img.png";

            IdentityResult result = await _userManager.CreateAsync(user, dto.Password);
        
            if (!result.Succeeded)
            {
                throw new ApplicationException(result.Errors.First().Description);
            }

            return _mapper.Map<ReadUserDto>(user);
        }
    }
}
