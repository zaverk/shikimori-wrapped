using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using shiki.Global_properties.Bases;
using shiki.Global_properties.Classes;

namespace shiki.Global_properties
{
    internal class Animes
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
        [JsonProperty("aired_on")] public DateTimeOffset? AiredOn { get; set; }
        [JsonProperty("released_on")] public DateTimeOffset? ReleasedOn { get; set; }
        [JsonProperty("rating")] public string Rating { get; set; }
        [JsonProperty("english")] public string[] English { get; set; }
        [JsonProperty("japanese")] public string[] Japanese { get; set; }
        [JsonProperty("synonyms")] public string[] Synonyms { get; set; }
        [JsonProperty("license_name_ru")] public string License_name_ru { get; set; }
        [JsonProperty("duration")] public long Duration { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("description_html")] public string DescriptionHtml { get; set; }
        [JsonProperty("description_source")] public string DescriptionSource { get; set; }
        [JsonProperty("franchise")] public string Franchise { get; set; }
        [JsonProperty("favoured")] public bool Favoured { get; set; }
        [JsonProperty("anons")] public bool Anons { get; set; }
        [JsonProperty("ongoing")] public bool Ongoing { get; set; }
        [JsonProperty("thread_id")] public long? ThreadId { get; set; }
        [JsonProperty("topic_id")] public long? TopicId { get; set; }
        [JsonProperty("myanimelist_id")] public long? MyanimelistId { get; set; }
        [JsonProperty("rates_scores_stats")] public Rate[] RatesScoresStats { get; set; }
        [JsonProperty("rates_statuses_stats")] public Rate[] RatesStatusesStats { get; set; }
        [JsonProperty("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
        [JsonProperty("next_episode_at")] public DateTimeOffset? NextEpisodeAt { get; set; }
        [JsonProperty("genres")] public Genre[] Genres { get; set; }
        [JsonProperty("studios")] public Studio[] Studios { get; set; }
        [JsonProperty("videos")] public Video[] Videos { get; set; }
        [JsonProperty("screenshots")] public Screenshots[] Screens { get; set; }
        [JsonProperty("user_rate")] public PublicUserRate UserRate { get; set; }
    }

    public class Rate
    {
        [JsonProperty("name")] public string Name;

        [JsonProperty("value")] public long? Value;
    }
}
