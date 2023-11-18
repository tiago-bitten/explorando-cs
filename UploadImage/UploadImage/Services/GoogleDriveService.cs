using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;

namespace UploadImage.Services
{
    public class GoogleDriveService
    {
        String credentialPath = Path.Combine(Directory.GetCurrentDirectory(), "credential.json");

        public String UploadFile(IFormFile file)
        {
            using (var stream = new FileStream(credentialPath, FileMode.Open, FileAccess.Read))
            {
                var credential = GoogleCredential.FromStream(stream).CreateScoped(new[] { DriveService.Scope.Drive });
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "UploadImage"
                });

                var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = file.FileName
                };

                FilesResource.CreateMediaUpload request;
                using (var stream2 = file.OpenReadStream())
                {
                    request = service.Files.Create(fileMetadata, stream2, "image/jpeg");
                    request.Fields = "id";
                    request.Upload();
                }

                var fileDrive = request.ResponseBody;
                return fileDrive.Id;
            }
        }
    }
}
