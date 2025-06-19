using System.Net;

namespace Sanura.Core.Client
{
    public class Request
    {
        private readonly Uri uri;

        public Request(HttpMethod method, string url)
        {
            this.Method = method;
            this.uri = new Uri(url);
            this.QueryParams = new Dictionary<string, string>();
        }

        public HttpMethod Method
        {
            get;
            private set;
        }

        public Dictionary<string, string> QueryParams
        {
            get;
            private set;
        }

        public Uri ConstructUrl()
        {
            return this.QueryParams.Count > 0 ?
                new Uri(this.uri.AbsoluteUri + "?" + EncodeParameters(this.QueryParams)) :
                new Uri(this.uri.AbsoluteUri);
        }

        public object JsonParameter
        {
            get;
            set;
        }

        private static string EncodeParameters(Dictionary<string, string> data)
        {
            var result = "";
            var first = true;
            foreach (var pair in data)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    result += "&";
                }

                result += WebUtility.UrlEncode(pair.Key) + "=" + WebUtility.UrlEncode(pair.Value);
            }

            return result;
        }

        public void AddQueryParam(string name, string value)
        {
            AddParam(this.QueryParams, name, value);
        }

        private static void AddParam(Dictionary<string, string> dict, string name, string value)
        {
            dict.Add(name, value);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != typeof(Request))
            {
                return false;
            }

            var other = (Request)obj;
            return Method.Equals(other.Method) &&
                    this.uri.Equals(other.uri) &&
                    this.QueryParams.All(other.QueryParams.Contains);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Method?.GetHashCode() ?? 0) ^
                        (this.uri?.GetHashCode() ?? 0) ^
                        (this.QueryParams?.GetHashCode() ?? 0);
            }
        }
    }
}
