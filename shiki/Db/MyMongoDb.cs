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
        const string ConnectionString = "mongodb://localhost:27017";
        public MyMongoDb()
        {
        }

        public static async Task Dbtest()
        {
            var settings = MongoClientSettings.FromConnectionString(ConnectionString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("shiki");
            const int year = 2022;

            var myArCompletedResult = await shiki.Controllers.UsersController.GetAnimeRates(year);
            var myArCompletedResultOverall = await shiki.Controllers.UsersController.GetAnimeRates();
            
            var myCompletedAnimesInSpecificYearDb = database.GetCollection<AnimeRate>($"MyCompletedAnimesIn{year}");
            
            
            var myAnimeIdOverall = database.GetCollection<MyAnimeID>("MyCompletedAnimeIDsOverall");
            var myAnimesAnimeIdInSpecificYearDb =
                database.GetCollection<MyAnimeID>($"MyCompletedAnimesAnimeIdIn{year}");

            var mcsy = await myAnimeIdOverall.Find(FilterDefinition<MyAnimeID>.Empty).ToListAsync();
            // for (int i = 0; i < myArCompletedResult.Count; i++)
            // {
            //     try
            //     {
            //         Console.WriteLine($"Getting result for {i} page");
            //         var result = await GetAnimeById(mcsy[i].Id);
            //         if (myAnimeIdOverall.Find(id => id.Id == result.Id).CountDocuments() == 0)
            //         {
            //             await myAnimeIdOverall.InsertOneAsync(result);
            //         }
            //     }
            //     catch(Exception e)
            //     {
            //         Console.WriteLine($"Caught exception on {i} page: {e}");
            //         Console.WriteLine("Retrying in 1 second");
            //         Thread.Sleep(1000);
            //         i--;
            //     }
            // }

            var mmtest = myAnimeIdOverall.Find(FilterDefinition<MyAnimeID>.Empty).ToList();
            var wastedMinutes = mmtest.Sum(anime => (anime.Episodes * anime.Duration)); //TODO calculate not only completed rates (would be epic)
            Console.WriteLine($"In {year} year you waste: {wastedMinutes} minutes, its a {wastedMinutes / 60} hours and {(wastedMinutes / 60) / 24} days by watching anime");
        }
        
        public static async Task GetAnimes()
        {
            var listAnimes = new List<Anime>();
            var myClient = Di.MyShikimoriClient();
            var temp = await myClient.Animes.GetAnime();
            listAnimes.AddRange(temp);
        }

        public static async Task<MyAnimeID> GetAnimeById(long id)
        {
            var myClient = Di.MyShikimoriClient();
            return await myClient.MyAnimes.GetAnime1(id);
        }
    }
}
