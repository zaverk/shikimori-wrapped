using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace shiki
{
    internal class Image
    {
        [JsonProperty("original")]
        public string Original { get; set; }

        [JsonProperty("preview")]
        public string Preview { get; set; }

        [JsonProperty("x96")]
        public string X96 { get; set; }

        [JsonProperty("x48")]
        public string X48 { get; set; }
    }
}
