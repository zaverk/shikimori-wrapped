using Newtonsoft.Json;
using shiki.Global_properties.Classes;

namespace shiki.Global_properties.old
{
    internal class User_anime_rates
    {
        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("score")] public int Score { get; set; }

        [JsonProperty("status")] public string Status { get; set; }

        [JsonIgnore] public string Text { get; set; }

        [JsonProperty("episodes")] public int Episodes { get; set; }

        [JsonIgnore] public int Chapters { get; set; }

        [JsonIgnore] public int Volumes { get; set; }

        [JsonIgnore] public string Text_html { get; set; }

        [JsonProperty("rewatches")] public int Rewatches { get; set; }

        [JsonProperty("user")] public User User { get; set; }

        [JsonProperty("anime")] public Target Anime { get; set; }

        [JsonProperty("created_at")] public DateTime created_at { get; set; }

        [JsonProperty("updated_at")] public DateTime updated_at { get; set; }
    }
}
