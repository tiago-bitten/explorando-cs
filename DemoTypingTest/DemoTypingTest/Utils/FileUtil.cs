namespace DemoTypingTest.Utils
{
    public class FileUtil
    {
        public const string DEFAULT_PROFILE_IMAGE_KEY = "1CRRST2k2Tl_5I2f4HJU9Et5BlK3bQAyD";
        public static string ExtractFileName(string fileName)
        {
            return fileName[..fileName.LastIndexOf('.')];
        }

        public static string ExtractExtension(string fileName)
        {
            return fileName[fileName.LastIndexOf('.')..];
        }

        public static Boolean IsImage(string fileName)
        {
            string extension = ExtractExtension(fileName);
            return extension == ".jpg" || extension == ".jpeg" || extension == ".png";
        }
    }
}
