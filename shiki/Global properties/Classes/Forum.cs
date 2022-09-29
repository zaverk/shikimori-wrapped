using Newtonsoft.Json;

namespace shiki.Global_properties.Classes
{
    public class Forum
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("position")] public long Position { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("permalink")] public string Permalink { get; set; }
        [JsonProperty("url")] public string Url { get; set; }
    }
}