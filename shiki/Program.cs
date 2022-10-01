using Microsoft.Extensions.Logging;
using ShikimoriSharp;
using ShikimoriSharp.Bases;
using shiki.Models;
using shiki.Controllers;
using shiki.Db;

namespace shiki
{
    public static class Program
    {
        public static async Task Main()
        {
            await MyMongoDb.GetAnimeById();
            //await UsersController.GetAnimeRates();
            //await HistoryController.Watched();
        }
    }
}
