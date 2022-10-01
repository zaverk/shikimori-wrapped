using Newtonsoft.Json;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shiki.Models
{
    public class MyAnimeID
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("russian")] public string Russian { get; set; }
        [JsonProperty("kind")] public string Kind { get; set; }
        [JsonProperty("score")] public double Score { get; set; }
        [JsonProperty("status")] public string Status { get; set; }
        [JsonProperty("episodes")] public long Episodes { get; set; }
        [JsonProperty("episodes_aired")] public long EpisodesAired { get; set; }
        [JsonProperty("rating")] public string Rating { get; set; }
        [JsonProperty("duration")] public long Duration { get; set; }
        [JsonProperty("myanimelist_id")] public long MyAnimeListId { get; set; }
        [JsonProperty("genres")] public Genre[] Genres { get; set; }
        //[JsonProperty("studios")] public Studio Studios { get; set; }
        [JsonProperty("user_rate")] public int? UserRate { get; set; }
    }
}
