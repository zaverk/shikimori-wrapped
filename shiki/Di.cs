using Microsoft.Extensions.Logging;
using shiki.Models;
using shiki.Db;
using ShikimoriSharp.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShikimoriSharp.Classes;
using ShikimoriSharp.Settings;

namespace shiki
{
    public class Di
    {
        public static MyShikimoriClient MyShikimoriClient()
        {
            var temp = new LoggerFactory();
            var logger = temp.CreateLogger("logger");
            return new MyShikimoriClient(logger, new ClientSettings("ClientName", "ClientID", "ClientSecret"));
        }
        
        public static async Task MyMongoDb()
        {
            var mongoDb = new MyMongoDb();
            await Db.MyMongoDb.GetAnimes();
        }

        public static async Task<MyAnimeID> MyGetAnimeById(long animeId)
        {
            var myClient = MyShikimoriClient();
            return await myClient.MyAnimes.GetAnime1(animeId);
        }
        
        public static async Task<List<AnimeRate>> GetUserCompletedAnimeRates(string username)
        {
            var listAnimeRates = new List<AnimeRate>();
            var myClient = MyShikimoriClient();
            var userId = (await myClient.Users.GetUser($"{username}")).Id;
            var pages = 1;
            var temp = await myClient.MyUsers.GetUserAnimeRates(userId, new AnimeRateRequestWithStatusSettings { limit=5000, page=pages, status="completed" } );
            listAnimeRates.AddRange(temp);
            while (temp != null)
            {
                pages++;
                temp = await myClient.MyUsers.GetUserAnimeRates(userId, new AnimeRateRequestWithStatusSettings { limit=5000, page=pages, status="completed" } );
                if (temp != null)
                {
                    listAnimeRates.AddRange(temp);
                }
            }

            return listAnimeRates;
        }
        public static async Task GetAnimes()
        {
            var listAnimes = new List<Anime>();
            var myClient = Di.MyShikimoriClient();
            var pages = 1;
            var temp = await myClient.Animes.GetAnime(new AnimeRequestSettings { limit = 50, page = pages});
            listAnimes.AddRange(temp);
        }
    }
}
