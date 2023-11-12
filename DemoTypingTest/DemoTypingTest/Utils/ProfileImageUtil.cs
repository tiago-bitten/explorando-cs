namespace DemoTypingTest.Utils
{
    public class ProfileImageUtil
    {
        public const string DefaultProfileImage = "default-user-profile-img.png";
        private const string UploadProfileImagePath = "Assets/ProfileImages/";
        private static readonly List<string> AllowedExtensions = new List<string> { "jpg", "jpeg", "png" };

        public static async Task<string> Upload(IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                throw new ApplicationException("Image is required");
            }

            var extension = Path.GetExtension(image.FileName)?.TrimStart('.');
            if (!AllowedExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase))
            {
                throw new ApplicationException("Invalid image extension");
            }

            var fileName = $"{Guid.NewGuid()}.{extension}";

            var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), UploadProfileImagePath);
            if (!Directory.Exists(uploadDir))
            {
                Directory.CreateDirectory(uploadDir);
            }

            var filePath = Path.Combine(uploadDir, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            return fileName;
        }

        public static byte[] Recover(string profileImageUrl)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), UploadProfileImagePath, profileImageUrl);
            return File.ReadAllBytes(filePath);
        }

        public static void Delete(string profileImageUrl)
        {
            if (profileImageUrl.Equals(DefaultProfileImage, StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), UploadProfileImagePath, profileImageUrl);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
