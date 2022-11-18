

using Newtonsoft.Json;

namespace Business.Models
{
    public sealed class User
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Name { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Username { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Email { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Address? Address { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Phone { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Website { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Company? Company { get; set; }
    }
}