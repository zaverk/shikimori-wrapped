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
