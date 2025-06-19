using System.Net;

namespace Sanura.Core.Client
{
    public class Response
    {
        public Response(HttpStatusCode statusCode, string content)
        {
            this.StatusCode = statusCode;
            this.Content = content;
        }

        public string Content
        {
            get;
            private set;
        }

        public HttpStatusCode StatusCode
        {
            get;
            private set;
        }
    }
}
