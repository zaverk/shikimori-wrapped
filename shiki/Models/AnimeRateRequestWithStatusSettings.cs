using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShikimoriSharp;
using ShikimoriSharp.Settings;

namespace shiki.Models
{
    public class AnimeRateRequestWithStatusSettings : AnimeRateRequestSettings
    {
        public string status { get; set; }
    }
}
