using Newtonsoft.Json;

namespace shiki.Global_properties.Classes
{
    public class Activity
    {
        [JsonProperty("name")] public long[] Name { get; set; }
        [JsonProperty("value")] public long? Value { get; set; }
    }
}