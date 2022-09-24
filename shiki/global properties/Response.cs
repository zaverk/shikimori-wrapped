using Newtonsoft.Json;

namespace shiki.global_properties
{
    internal class History
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("target")]
        public Target Target { get; set; }
    }
    internal class UserId
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonIgnore]
        public string nickname { get; set; }

        [JsonIgnore]
        public string avatar { get; set; }

        [JsonIgnore]
        public Image image { get; set; }

        [JsonIgnore]
        public DateTime? last_online_at { get; set; }

        [JsonIgnore]
        public string url { get; set; }

        [JsonIgnore]
        public string name { get; set; }

        [JsonIgnore]
        public string sex { get; set; }

        [JsonIgnore]
        public int full_years { get; set; }

        [JsonIgnore]
        public string last_online { get; set; }

        [JsonIgnore]
        public string website { get; set; }

        [JsonIgnore]
        public string about { get; set; }

        [JsonIgnore]
        public string about_html { get; set; }

        [JsonIgnore]
        public Common_info common_info { get; set; }

        [JsonIgnore]
        public bool show_comments { get; set; }

        [JsonIgnore]
        public bool in_friends { get; set; }

        [JsonIgnore]
        public bool is_ignored { get; set; }

        [JsonIgnore]
        public Stats stats { get; set; }

        [JsonIgnore]
        public long style_id { get; set; }
    }
    internal class User_anime_rates
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonIgnore]
        public string Text { get; set; }

        [JsonProperty("episodes")]
        public int Episodes { get; set; }

        [JsonIgnore]
        public int Chapters { get; set; }

        [JsonIgnore]
        public int Volumes { get; set; }

        [JsonIgnore]
        public string Text_html { get; set; }

        [JsonProperty("rewatches")]
        public int Rewatches { get; set; }

        [JsonIgnore]
        public User User { get; set; }

        [JsonProperty("anime")]
        public Target Anime { get; set; }

        

        

        

        

        

        

        

        

        [JsonProperty("created_at")]
        public DateTime created_at { get; set; }

        [JsonProperty("updated_at")]
        public DateTime updated_at { get; set; }
    }
}
