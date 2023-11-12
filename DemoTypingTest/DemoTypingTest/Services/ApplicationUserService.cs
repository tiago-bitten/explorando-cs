using AutoMapper;
using DemoTypingTest.Data;
using DemoTypingTest.Data.Dtos;
using DemoTypingTest.Models;
using DemoTypingTest.Utils;
using Microsoft.AspNetCore.Identity;

namespace DemoTypingTest.Services
{
    public class ApplicationUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserService(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<ReadApplicationUserDto> Create(CreateUserDto dto)
        {
            ApplicationUser user = _mapper.Map<ApplicationUser>(dto);
            user.ProfileImageURL = "default-profile-img.png";

            IdentityResult result = await _userManager.CreateAsync(user, dto.Password);
        
            if (!result.Succeeded)
            {
                throw new ApplicationException(result.Errors.First().Description);
            }

            return _mapper.Map<ReadApplicationUserDto>(user);
        }

        public async Task<ReadApplicationUserDto> FindById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new ApplicationException("User not found");
            }

            return _mapper.Map<ReadApplicationUserDto>(user);
        }

        public async Task<ReadApplicationUserDto> UploadProfileImage(IFormFile file, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            string profileImageUrl = await ProfileImageUtil.Upload(file);

            user.ProfileImageURL = profileImageUrl;
            await _userManager.UpdateAsync(user);

            return _mapper.Map<ReadApplicationUserDto>(user);
        }
    }
}
