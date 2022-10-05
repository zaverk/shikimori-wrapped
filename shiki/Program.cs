using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using ShikimoriSharp;
using ShikimoriSharp.Bases;
using shiki.Models;
using shiki.Controllers;
using shiki.Repository;
using shiki.Services;
using ShikimoriSharp.Classes;
using ShikimoriSharp.Enums;

namespace shiki
{
    public static class Program
    {
        public static async Task Main()
        {
            var db = new DbRepo();
            var us = new UserServices();
            //await db.Dbtest();
            //await HistoryController.Watched();
            //await UserServices.GetAnimeRatesPrint();
            //await us.GetAnimeRatesPrint();
            await db.NewPrintTest();
        }
        public static IMongoDatabase MongoClient()
        {
            const string connectionString = "mongodb://localhost:27017";
            var settings = MongoClientSettings.FromConnectionString(connectionString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            return client.GetDatabase("shiki");
        }
        public static ShikimoriClient ShikimoriClient()
        {
            var temp = new LoggerFactory();
            var logger = temp.CreateLogger("logger");
            return new ShikimoriClient(logger, new ClientSettings("ClientName", "ClientID", "ClientSecret"));
        }
    }
}
