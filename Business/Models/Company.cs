using Newtonsoft.Json;

namespace Business.Models
{
    public sealed class Company
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Name { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? CatchPhrase { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Bs { get; set; }
    }
}