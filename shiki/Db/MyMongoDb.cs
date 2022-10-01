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
        public MyMongoDb()
        {
            var connectionString = "mongodb://localhost:27017";
            var settings = MongoClientSettings.FromConnectionString(connectionString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("test");
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

        public static async Task GetAnimeById()
        {
            var list = new List<MyAnimeID>();
            var myClient = Di.MyShikimoriClient();
            var id = 17;
            var temp = await myClient.MyAnimes.GetAnime1(id);
            list.Add(temp);
        }
    }
}
