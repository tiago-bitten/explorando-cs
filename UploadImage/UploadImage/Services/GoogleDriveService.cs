using AutoMapper;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using System.Security.Cryptography.X509Certificates;
using UploadImage.Dtos;

namespace UploadImage.Services
{
    public class GoogleDriveService
    {
        private readonly IMapper _mapper;

        public GoogleDriveService(IMapper mapper)
        {
            _mapper = mapper;
        }

        String credentialPath = Path.Combine(Directory.GetCurrentDirectory(), "Data","credentials.json");

        public Google.Apis.Drive.v3.Data.File Upload(IFormFile file, string fileName)
        {
            using (var stream = new FileStream(credentialPath, FileMode.Open, FileAccess.Read))
            {
                var credential = GoogleCredential.FromStream(stream).CreateScoped(new[] { DriveService.Scope.Drive });
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Dejotageek"
                });

                var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = fileName,
                };

                FilesResource.CreateMediaUpload request;
                using (var stream2 = file.OpenReadStream())
                {
                    request = service.Files.Create(fileMetadata, stream2, "image/jpeg");
                    request.Fields = "id";
                    request.Upload();
                }

                return request.ResponseBody;
            }
        }

        public async Task<byte[]> Recover(string imageKey)
        {
            using (var stream = new FileStream(credentialPath, FileMode.Open, FileAccess.Read))
            {
                var credential = GoogleCredential.FromStream(stream).CreateScoped(new[] { DriveService.Scope.Drive });
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Dejotageek"
                });

                var request = service.Files.Get(imageKey);
                var stream2 = new System.IO.MemoryStream();
                await request.DownloadAsync(stream2);
                return stream2.ToArray();
            }
        }
    }
}
