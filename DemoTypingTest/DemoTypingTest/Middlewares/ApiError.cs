namespace DemoTypingTest.Middlewares
{
    public class ApiError
    {
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        public int StatusCode { get; set; }
        public string Path { get; set; }
        public string Message { get; set; }

        public ApiError()
        {
        }

        public ApiError(string message, string path, int statusCode)
        {
            StatusCode = statusCode;
            Path = path;
            Message = message;
        }
    }
}
