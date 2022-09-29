﻿using Newtonsoft.Json;

namespace shiki.Global_properties.Classes
{
    public class Statuses
    {
        [JsonProperty("anime")] public FullStatusesAnime[] Anime { get; set; }
        [JsonProperty("manga")] public FullStatusesAnime[] Manga { get; set; }
    }

    public class FullStatusesAnime
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("grouped_id")] public string GroupedId { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("size")] public long? Size { get; set; }
        [JsonProperty("type")] public string Type { get; set; }
    }
}