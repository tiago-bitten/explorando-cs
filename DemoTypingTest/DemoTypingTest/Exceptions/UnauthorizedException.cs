namespace DemoTypingTest.Exceptions
{
    public class UnauthorizedException : UnauthorizedAccessException
    {
        public UnauthorizedException(string message) : base(message)
        {
        }
    }
}
