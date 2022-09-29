using Newtonsoft.Json;

namespace shiki.Global_properties.Classes
{
    public class Screenshots
    {
        [JsonProperty("original")] public string Original { get; set; }
        [JsonProperty("preview")] public string Preview { get; set; }
    }
}