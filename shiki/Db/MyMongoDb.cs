using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;
using shiki.Models;
using ShikimoriSharp;
using ShikimoriSharp.Classes;
using ShikimoriSharp.Settings;


namespace shiki.Db
{
    public class MyMongoDb
    {
        const string connectionString = "mongodb://localhost:27017";
        public MyMongoDb()
        {
        }

        public static async Task Dbtest()
        {
            var settings = MongoClientSettings.FromConnectionString(connectionString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("shiki");
            const int year = 2022;

            var myAnimeRatesResult = await shiki.Controllers.UsersController.GetAnimeRates(year);
            var myCompletedAnimesInSpecificYearDb = database.GetCollection<AnimeRate>($"MyCompletedAnimesIn{year}");

            var myAnimesAnimeIdOverall = database.GetCollection<MyAnimeID>("MyCompletedAnimeIDs");
            var myAnimesAnimeIdInSpecificYearDb =
                database.GetCollection<MyAnimeID>($"MyCompletedAnimesAnimeIdIn{year}");

            var mcsy = await myCompletedAnimesInSpecificYearDb.Find(FilterDefinition<AnimeRate>.Empty).ToListAsync();
            for (int i = 0; i < mcsy.Count; i++)
            {
                try
                {
                    Console.WriteLine($"Getting result for {i} page");
                    var result = await GetAnimeById(mcsy[i].Anime.Id);
                    await myAnimesAnimeIdInSpecificYearDb.InsertOneAsync(result);
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Caught exception on {i} page: {e}");
                    Console.WriteLine("Retrying in 1 second");
                    Thread.Sleep(1000);
                    i--;
                }
            }

            //var mmtest = myAnimesAnimeIdInSpecificYearDb.Find(FilterDefinition<MyAnimeID>.Empty).ToList();
            //var wastedMinutes = mmtest.Sum(anime => (anime.Episodes * anime.Duration)); //TODO calculate not only completed rates (would be epic)
            //Console.WriteLine($"In {year} year you waste: {wastedMinutes / 60} hours by watching anime");
        }
        
        public static async Task GetAnimes()
        {
            var listAnimes = new List<Anime>();
            var myClient = Di.MyShikimoriClient();
            var temp = await myClient.Animes.GetAnime();
            listAnimes.AddRange(temp);
            
            //var httpsClient = new HttpClient();
            //var response = await httpsClient.GetAsync($"https://shikimori.one/api/animes/1");
            //var jsonResponse = await response.Content.ReadAsStringAsync();
            //var result = JsonConvert.DeserializeObject<MyAnimeID>(jsonResponse);
            //var bsontest = result.ToBsonDocument();
        }

        public static async Task<MyAnimeID> GetAnimeById(long id)
        {
            var myClient = Di.MyShikimoriClient();
            return await myClient.MyAnimes.GetAnime1(id);
        }
    }
}
