using Newtonsoft.Json;

namespace Sanura.Core.Client
{
    public class ErrorResponse
    {
        [JsonProperty("errors")]
        public List<Error> Errors
        {
            get;
            set;
        }
    }
}
