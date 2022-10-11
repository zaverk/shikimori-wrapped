using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;
using shiki.Models;
using ShikimoriSharp.Classes;
using shiki.Controllers;
using shiki.Services;
using ShikimoriSharp.Enums;
using Anime = shiki.Models.Anime;
using Exception = System.Exception;

namespace shiki.Repository
{
    public class DbRepo : IDbRepo
    {
        protected static IMongoDatabase _shikidb = Program.MongoClient();
        
        public async Task Dbtest()
        {
            const int year = 2022;
            const string username = "zaverk";
            var myArCompletedResult = await shiki.Controllers.UsersController.GetUserAnimeRatesInSpecificYear(year, username, MyList.completed);
            var myAnimesAnimeIdInSpecificYearDb = _shikidb?.GetCollection<Anime>($"MyCompletedAnimesAnimeIdIn{year}");
            var myArCompletedResultOverall = await shiki.Controllers.UsersController.GetUserAnimeRates("zaverk", MyList.completed);
            var myAnimeIdOverall = _shikidb?.GetCollection<AnimeID>("MyCompletedAnimeIDsOverall");
            var mcsy = await myAnimeIdOverall.Find(FilterDefinition<AnimeID>.Empty).ToListAsync();
            
            var myHistory = _shikidb?.GetCollection<History[]>($"{username}'s history");
            //await myHistory.InsertManyAsync(historyResult);

            for (int i = 0; i < myArCompletedResult.Count; i++)
            {
                try
                {
                    Console.WriteLine($"Getting result for {i} page");
                    var result = await AnimeController.GetAnimeById(mcsy[i].Id);
                    if (myAnimeIdOverall.Find(id => id.Id == result.Id).CountDocuments() == 0)
                    {
                        await myAnimeIdOverall.InsertOneAsync(result);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Caught exception on {i} page: {e}");
                    Console.WriteLine("Retrying in 1 second");
                    Thread.Sleep(1000);
                    i--;
                }
            }

            var mmtest = myAnimeIdOverall.Find(FilterDefinition<AnimeID>.Empty).ToList();
            var wastedMinutes = mmtest.Sum(anime => (anime.Episodes * anime.Duration)); //TODO calculate not only completed rates (would be epic)
            Console.WriteLine($"you waste: {wastedMinutes} minutes, its a {wastedMinutes / 60} hours and {(wastedMinutes / 60) / 24} days by watching anime");
        }
        public async Task AddUserAnimeRates(string username, List<AnimeRate> list)
        {
            var userCompletedAnimes = _shikidb?.GetCollection<AnimeRate>($"{username}'s Anime Rates");
            await userCompletedAnimes!.InsertManyAsync(list);
        }
        public async Task<List<AnimeRate>> GetUserAnimeRates(string username)
        {
            var userCompletedAnimes = _shikidb?.GetCollection<AnimeRate>($"{username}'s Anime Rates");
            return await userCompletedAnimes.Find(FilterDefinition<AnimeRate>.Empty).ToListAsync();
        }
        public Task AddUserAnime()
        {
            throw new NotImplementedException();
        }
        public Task<List<Anime>> GetUserAnime()
        {
            throw new NotImplementedException();
        }
        public Task AddUserHistory()
        {
            throw new NotImplementedException();
        }
        public Task<List<History[]>> GetUserHistory()
        {
            throw new NotImplementedException();
        }
        public Task AddAnime()
        {
            throw new NotImplementedException();
        }
        public Task<List<Anime>> GetAnime()
        {
            throw new NotImplementedException();
        }
    }
}