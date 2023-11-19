using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;

namespace DemoTypingTest.Services
{
    public class GoogleDriveService
    {
        private readonly string credentialsPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "credentials.json");

        public const string DEFAULT_PROFILE_IMAGE_KEY = "1CRRST2k2Tl_5I2f4HJU9Et5BlK3bQAyD";

        public Google.Apis.Drive.v3.Data.File Upload(IFormFile file, string fileName)
        {
            using var stream = new FileStream(credentialsPath, FileMode.Open, FileAccess.Read);
            var credential = GoogleCredential.FromStream(stream).CreateScoped(new string[] { DriveService.Scope.Drive });
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Dejotageek"
            });

            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = fileName
            };

            FilesResource.CreateMediaUpload request;
            using (var stream2 = file.OpenReadStream())
            {
                request = service.Files.Create(fileMetadata, stream2, "image/png");
                request.Fields = "id";
                request.Upload();
            }

            return request.ResponseBody;
        }

        public async Task<byte[]> Recover(string imageKey)
        {
            using var stream = new FileStream(credentialsPath, FileMode.Open, FileAccess.Read);
            var credential = GoogleCredential.FromStream(stream).CreateScoped(new string[] { DriveService.Scope.Drive });
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Dejotageek"
            });

            var request = service.Files.Get(imageKey);
            var stream2 = new MemoryStream();
            await request.DownloadAsync(stream2);
            return stream2.ToArray();
        }
    }
}
