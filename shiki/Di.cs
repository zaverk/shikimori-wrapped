using ShikimoriSharp;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Classes;
using ShikimoriSharp.Settings;
using shiki.Repository;
using Microsoft.Extensions.Logging;

namespace shiki
{
    public class Di
    {
        private static ShikimoriClient _shikimoriClient;
        public Di(ShikimoriClient shikimoriClient)
        {
            _shikimoriClient = shikimoriClient;
        }
        public static async Task MyMongoDb()
        {
            //var mongoDb = new DbRepo(MongoClient());
            await Controllers.AnimeController.GetAnimes();
        }
        
        public static async Task<List<Anime>> GetAnimes() // trf
        {
            var listAnimes = new List<Anime>();
            var pages = 1;
            var temp = await _shikimoriClient.Animes.GetAnime(new AnimeRequestSettings { limit = 50, page = pages});
            listAnimes.AddRange(temp);
            return listAnimes;
        }
        
    }
}
