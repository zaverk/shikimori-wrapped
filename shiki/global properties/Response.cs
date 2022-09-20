using Newtonsoft.Json;

namespace shiki.global_properties
{
    internal class History
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("target")]
        public Target Target { get; set; }

    }
}
