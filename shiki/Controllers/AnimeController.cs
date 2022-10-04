using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shiki.Models;
using ShikimoriSharp;
using ShikimoriSharp.Classes;
using ShikimoriSharp.Settings;

namespace shiki.Controllers
{
    public class AnimeController
    {
        private static ShikimoriClient _shikimoriClient;
        public AnimeController(ShikimoriClient shikimoriClient)
        {
            _shikimoriClient = shikimoriClient;
        }
        public static async Task GetAnimes()
        {
            var listAnimes = new List<ShikimoriSharp.Classes.Anime>();
            var temp = await _shikimoriClient.Animes.GetAnime();
            listAnimes.AddRange(temp);
        }
        public static async Task<AnimeID> GetAnimeById(long id)
        {
            return await _shikimoriClient.Animes.GetAnime(id);
        }
    }
}
