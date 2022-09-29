using System;
using Newtonsoft.Json;
using shiki.Global_properties.Bases;

namespace shiki.Global_properties.Classes
{
    public class Moderator
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("nickname")] public string Nickname { get; set; }
        [JsonProperty("avatar")] public Uri Avatar { get; set; }
        [JsonProperty("image")] public PureImage Image { get; set; }
        [JsonProperty("last_online_at")] public DateTimeOffset? LastOnlineAt { get; set; }
    }
}