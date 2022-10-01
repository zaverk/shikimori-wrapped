using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;
using shiki.Models;

namespace shiki.Db
{
    public class MongoDb
    {
        public MongoDb()
        {
            var ConnectionString = "mongodb://localhost:27017";
            var settings = MongoClientSettings.FromConnectionString(ConnectionString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("test");
        }
        public static async Task ResponseToBson()
        {
            var https_client = new HttpClient();
            var response = await https_client.GetAsync($"https://shikimori.one/api/animes/1");
            var json_response = await response.Content.ReadAsStringAsync();
            MyAnimeID? result = JsonConvert.DeserializeObject<MyAnimeID>(json_response);
            var bsontest = result.ToBsonDocument();
        }
    }
}
