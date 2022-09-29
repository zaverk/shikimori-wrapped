using Newtonsoft.Json;
using shiki.Global_properties.Classes;

namespace shiki.Global_properties.AdditionalRequests
{
    public class Related
    {
        [JsonProperty("relation")] public string Relation { get; set; }

        [JsonProperty("relation_russian")] public string RelationRussian { get; set; }

        [JsonProperty("anime")] public Anime Anime { get; set; }

        [JsonProperty("manga")] public Manga Manga { get; set; }
    }
}