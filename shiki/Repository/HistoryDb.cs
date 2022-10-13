using MongoDB.Driver;
using shiki.Services;
using ShikimoriSharp.Classes;

namespace shiki.Repository;

public class HistoryDb : DbRepo
{
    public async Task<List<History>> GetUserHistoryCompletedList(string username)
    {
        var builder = Builders<History>.Filter;
        var filter = builder.Eq("description", "Просмотрено") | builder.Where(f => f.Description.Contains("Просмотрено и оценено"));
        var userHistory = _shikidb.GetCollection<History>($"{username}'s history");
        return await userHistory.Find<History>(filter).ToListAsync();
    }
    
    // public async Task GetUserHistory(string username)
    // {
    //     var newDbTest = _shikidb.GetCollection<History>($"{username}'s history");
    //     var response = await UserServices.GetUserHistory($"{username}");
    //     await newDbTest.InsertManyAsync(response);
    // }

    public async Task GetUserHistory(string username) 
    {
        var userHistory = _shikidb.GetCollection<History>($"{username}'s history");
        var newDbTest = _shikidb.GetCollection<History>("History test");
        var response = await userHistory.Find(FilterDefinition<History>.Empty).ToListAsync();
        var result = response.Where(h => (h.Description == "Просмотрено"
                                          || h.Description.Contains("Просмотрено и оценено"))).ToList();
                                          /*&& h.CreatedAt.Year == year)*/
        await newDbTest.InsertManyAsync(result);
    }

    // public async Task GetHistoryFromUserRates(string username)
    // {
    //     var getHistoryFromUserRatesDb = _shikidb.GetCollection<History>("123");
    //     var input = await UserServices.PrintHistoriesMatches(username);
    //     await getHistoryFromUserRatesDb.InsertManyAsync(input);
    // }
}