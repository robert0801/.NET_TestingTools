using Newtonsoft.Json;

namespace Business.Models
{
    public sealed class Geo
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Lat { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Lng { get; set; }
    }
}