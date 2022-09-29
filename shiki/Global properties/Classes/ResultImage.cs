﻿using Newtonsoft.Json;

namespace shiki.Global_properties.Classes
{
    public class ResultImage
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("preview")] public string Preview { get; set; }
        [JsonProperty("url")] public string Url { get; set; }
        [JsonProperty("bbcode")] public string Bbcode { get; set; }
    }
}