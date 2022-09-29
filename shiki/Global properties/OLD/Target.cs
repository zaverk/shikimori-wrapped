using System.Text.Json;
using Newtonsoft.Json;
using shiki.Global_properties.Bases;

namespace shiki.Global_properties
{
    internal class Target
    {
        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("russian")] public string Russian { get; set; }

        [JsonProperty("image")] public Image Image { get; set; }

        [JsonProperty("url")] public string Url { get; set; }

        [JsonProperty("kind")] public string Kind { get; set; }

        [JsonProperty("score")] public string Score { get; set; }

        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("episodes")] public long Episodes { get; set; }

        [JsonProperty("episodes_aired")] public long EpisodesAired { get; set; }

        [JsonProperty("aired_on")] public DateTime? AiredOn { get; set; }

        [JsonProperty("released_on")] public DateTime? ReleasedOn { get; set; }
    }
}
