using AutoMapper;
using DemoTypingTest.Data;
using DemoTypingTest.Data.Dtos;
using DemoTypingTest.Models;
using Microsoft.AspNetCore.Identity;

namespace DemoTypingTest.Services
{
    public class UserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IdentityUserDbContext _context;

        public UserService(IMapper mapper, UserManager<ApplicationUser> userManager, IdentityUserDbContext context)
        {
            _mapper = mapper;
            _userManager = userManager;
            _context = context;
        }

        public async Task<ReadUserDto> Create(CreateUserDto dto)
        {
            ApplicationUser user = _mapper.Map<ApplicationUser>(dto);
            user.ProfileImageURL = "default-profile-img.png";

            IdentityResult result = await _userManager.CreateAsync(user, dto.Password);
        
            if (!result.Succeeded)
            {
                throw new ApplicationException(result.Errors.First().Description);
            }

            return _mapper.Map<ReadUserDto>(user);
        }

        public async Task AddTest(Test test)
        {
            await _context.Tests.AddAsync(test);
        }
    }
}
