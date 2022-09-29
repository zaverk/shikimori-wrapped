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
    public class DI
    {
        public static MyShikimoriClient MyShikimoriClient()
        {
            var temp = new LoggerFactory();
            var logger = temp.CreateLogger("logger");
            return new MyShikimoriClient(logger, new ClientSettings("ClientName", "ClientID", "ClientSecret"));
        }
        
        public static async Task MyMongoDB()
        {
            MongoDb MongoDb = new MongoDb();
            await MongoDb.ResponseToBson();
        }

        public static async Task<MyAnimeID> MyGetAnimeByID(long AnimeId)
        {
            var MyClient = MyShikimoriClient();
            return await MyClient.MyAnimes.GetAnime1(AnimeId);
        }
            
        public static async Task<List<AnimeRate>> MyGetUserAnimeRates(string Username)
        {
            var ListAnimeRates = new List<AnimeRate>();
            var MyClient = MyShikimoriClient();
            long userId = (await MyClient.Users.GetUser($"{Username}")).Id;
            var pages = 1;
            string c = "completed";
            AnimeRate[] temp = await MyClient.MyUsers.GetUserAnimeRates(userId, new AnimeRateRequestWithStatusSettings { limit=5000, page=1, status=c } );
            ListAnimeRates.AddRange(temp);
            //while (temp != null)
            //{
            //    pages++;
            //    temp = await MyClient.MyUsers.GetUserAnimeRates(userId);
            //    ListAnimeRates.AddRange(temp);
            //}

            return ListAnimeRates;
        }
    }
}
