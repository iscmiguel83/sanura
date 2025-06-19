namespace Sanura.Core.Client
{
    public class ApiConnectionException : Exception
    {
        public ApiConnectionException(string message)
            : base(message)
        {
        }

        public ApiConnectionException(string message, Exception exception)
            : base(message, exception)
        {
        }
    }
}