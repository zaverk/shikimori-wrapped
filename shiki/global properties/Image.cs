using System.Text.Json;
using Newtonsoft.Json;

namespace shiki.global_properties
{
    internal class Image
    {
        [JsonProperty("original")]
        public string Original { get; set; }

        [JsonProperty("preview")]
        public string Preview { get; set; }

        [JsonProperty("x96")]
        public string X96 { get; set; }

        [JsonProperty("x48")]
        public string X48 { get; set; }
    }
}
