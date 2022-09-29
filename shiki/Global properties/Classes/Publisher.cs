using Newtonsoft.Json;

namespace shiki.Global_properties.Classes
{
    public class Publisher
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
    }
}