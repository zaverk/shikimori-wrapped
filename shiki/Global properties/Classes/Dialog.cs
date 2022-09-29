using Newtonsoft.Json;

namespace shiki.Global_properties.Classes
{
    public class Dialog
    {
        [JsonProperty("target_user")] public User TargetUser { get; set; }
        [JsonProperty("message")] public MessageContent Message { get; set; }
    }
}