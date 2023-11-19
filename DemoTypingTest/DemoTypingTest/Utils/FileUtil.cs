namespace DemoTypingTest.Utils
{
    public class ProfileImageUtil
    {
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
