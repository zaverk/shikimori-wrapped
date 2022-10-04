using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shiki.Models;

namespace shiki.Db
{
    internal class AnimeOnDb : Anime
    {
        public DateTime expires_at { get; set; }
    }
}
