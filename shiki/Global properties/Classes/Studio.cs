using Newtonsoft.Json;
using shiki.Global_properties.Bases;

namespace shiki.Global_properties.Classes
{
    public class Studio
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("filtered_name")] public string FilteredName { get; set; }
        [JsonProperty("real")] public bool? Real { get; set; }
        [JsonProperty("image")] public Image Image { get; set; }
    }
}