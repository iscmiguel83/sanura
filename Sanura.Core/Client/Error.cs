using Newtonsoft.Json;

namespace Sanura.Core.Client
{
    public class Error
    {
        [JsonProperty("status")]
        public string Status
        {
            get;
            set;
        }

        [JsonProperty("title")]
        public string Title
        {
            get;
            set;
        }

        [JsonProperty("detail")]
        public string Detail
        {
            get;
            set;
        }

        [JsonProperty("type")]
        public string Type
        {
            get;
            set;
        }
    }
}
