using AutoMapper;
using DemoTypingTest.Data.Dtos;
using DemoTypingTest.Exceptions;
using DemoTypingTest.Models;
using DemoTypingTest.Utils;
using Microsoft.AspNetCore.Identity;

namespace DemoTypingTest.Services
{
    public class ApplicationUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly GoogleDriveService _googleDriveService;

        public ApplicationUserService(IMapper mapper, UserManager<ApplicationUser> userManager,
            GoogleDriveService googleDriveService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _googleDriveService = googleDriveService;
        }

        public async Task<ReadApplicationUserDto> FindById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            return _mapper.Map<ReadApplicationUserDto>(user);
        }

        public async Task<ReadApplicationUserDto> UploadProfileImage(IFormFile file, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ValidationException("User not found");
            }
            
            if (file == null || file.Length == 0)
            {
                throw new ValidationException("Image is required");
            }

            string currentImageKey = user.ProfileImageKey;
            if (!currentImageKey.Equals(FileUtil.DEFAULT_PROFILE_IMAGE_KEY))
            {
                _googleDriveService.Delete(currentImageKey);
            }

            string fileName = FileUtil.ExtractFileName(file.FileName) + "__=)__" + Guid.NewGuid().ToString();
            Google.Apis.Drive.v3.Data.File uploadedFile = _googleDriveService.Upload(file, fileName);

            user.ProfileImageKey = uploadedFile.Id;
            await _userManager.UpdateAsync(user);

            return _mapper.Map<ReadApplicationUserDto>(user);
        }

        public async Task<byte[]> RecoverProfileImage(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ValidationException("User not found");
            }

            return await _googleDriveService.Recover(user.ProfileImageKey);
        }

        public async Task DeleteProfileImage(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ValidationException("User not found");
            }

            string currentImageKey = user.ProfileImageKey;
            if (currentImageKey.Equals(FileUtil.DEFAULT_PROFILE_IMAGE_KEY))
            {
                throw new ValidationException("User does not have a profile image");
            }

            _googleDriveService.Delete(user.ProfileImageKey);
            user.ProfileImageKey = FileUtil.DEFAULT_PROFILE_IMAGE_KEY;
            await _userManager.UpdateAsync(user);
        }
    }
}
