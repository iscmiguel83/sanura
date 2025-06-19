using System.Net;
using Newtonsoft.Json;

namespace Sanura.Core.Client
{
    public abstract class ClientBase
    {
        protected HttpClient httpClient;

        public ClientBase()
        {
            //this.httpClient = new HttpClient();
#if (DEBUG && (ANDROID || IOS))
            HttpsClientHandlerService handler = new HttpsClientHandlerService();
            this.httpClient = new HttpClient(handler.GetPlatformMessageHandler());
#else
            //this.httpClient = new HttpClient();
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            this.httpClient = new HttpClient(httpClientHandler);
#endif
        }

        protected Request LastRequest
        {
            get;
            private set;
        }

        protected Response LastResponse

        {
            get;
            private set;
        }

        public virtual Response MakeRequest(Request request)
        {
            try
            {
                var task = this.MakeRequestAsync(request);
                task.Wait();
                return task.Result;
            }
            catch (AggregateException ex)
            {
                ex = ex.Flatten();
                throw ex.InnerExceptions[0];
            }
        }

        public virtual async Task<Response> MakeRequestAsync(Request request)
        {
            var httpRequest = this.BuildHttpRequest(request);
            this.LastRequest = request;
            this.LastResponse = null;

            var response = await this.httpClient.SendAsync(httpRequest).ConfigureAwait(false);

            var reader = new StreamReader(await response.Content.ReadAsStreamAsync().ConfigureAwait(false));
            this.LastResponse = new Response(response.StatusCode, await reader.ReadToEndAsync().ConfigureAwait(false));

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.StatusCode.ToString());
            }

            return this.LastResponse;
        }

        protected virtual HttpRequestMessage BuildHttpRequest(Request request)
        {
            var httpRequest = new HttpRequestMessage(new System.Net.Http.HttpMethod(request.Method.ToString()), request.ConstructUrl());
            return httpRequest;
        }

        protected static Response ProcessResponse(Response response)
        {
            if (response == null)
            {
                throw new ApiConnectionException("Connection Error: No response received.");
            }

            if (response.StatusCode >= HttpStatusCode.OK && response.StatusCode < HttpStatusCode.Ambiguous)
            {
                return response;
            }

            throw new ApiConnectionException("Api Error: " + response.StatusCode + " - " + (response.Content ?? "[no content]"));
        }
    }

}
