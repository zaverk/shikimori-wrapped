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

    }
}
