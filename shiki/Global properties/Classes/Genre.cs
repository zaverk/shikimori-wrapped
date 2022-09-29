﻿using Newtonsoft.Json;

namespace shiki.Global_properties.Classes
{
    public class Genre
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("russian")] public string Russian { get; set; }
        [JsonProperty("kind")] public string Kind { get; set; }
    }
}