using Newtonsoft.Json;
using shiki.Global_properties.Bases;

namespace shiki.Global_properties.Classes
{
    public class Seyu
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("russian")] public string Russian { get; set; }
        [JsonProperty("image")] public Image Image { get; set; }
        [JsonProperty("url")] public string Url { get; set; }
    }
}