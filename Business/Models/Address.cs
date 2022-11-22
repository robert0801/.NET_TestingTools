using Newtonsoft.Json;

namespace Business.Models
{
    public sealed class Address
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Street { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Suite { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? City { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Zipcode { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Geo? Geo { get; set; }
    }
}