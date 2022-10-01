using Microsoft.Extensions.Logging;
using ShikimoriSharp;
using ShikimoriSharp.Bases;
using shiki.Models;
using shiki.Controllers;

namespace shiki
{
    public static class Program
    {
        public static async Task Main()
        {
            await UsersController.GetAnimeRates();
            //await HistoryController.Watched();
        }
    }
}
