using System.Text;
using ShikimoriSharp;
using ShikimoriSharp.Classes;
using ShikimoriSharp.Enums;
using ShikimoriSharp.Settings;
using shiki;

namespace shiki.Services;

public class UserServices
{
    private static readonly ShikimoriClient ShikimoriClient = Program.ShikimoriClient();
    public static async Task<List<UserRate>> GetUserRates(string username, MyList status)
    {
        var listUserRates = new List<UserRate>();
        var userId = (await ShikimoriClient.Users.GetUser($"{username}")).Id;
        var temp = await ShikimoriClient.UserRates.GetUsersRates( new UserRatesSettings { user_id = userId, status = status, target_type = TargetType.Anime } );
        listUserRates.AddRange(temp);
        return listUserRates;
    }
    
    public static async Task<List<UserRate>> GetUserRates(string username)
    {
        var listUserRates = new List<UserRate>();
        var userId = (await ShikimoriClient.Users.GetUser($"{username}")).Id;
        var temp = await ShikimoriClient.UserRates.GetUsersRates( new UserRatesSettings { user_id = userId, target_type = TargetType.Anime } );
        listUserRates.AddRange(temp);
        return listUserRates;
    }

    public static async Task<List<AnimeRate>> GetUserAnimeRates(string username)
    {
        var listAnimeRates = new List<AnimeRate>();
        var userId = (await ShikimoriClient.Users.GetUser($"{username}")).Id;
        var pages = 1;
        AnimeRate[]? response;
        do
        {
            response = await ShikimoriClient.Users.GetUserAnimeRates(userId, new AnimeRateRequestSettings{page = pages, limit = 5000});
            listAnimeRates.AddRange(response ?? Array.Empty<AnimeRate>());
            pages++;
        } while (response != null);

        return listAnimeRates;
    }
    public static async Task<List<AnimeRate>> GetUserStatusAnimeRates(string username, string status)
    {
        var listAnimeRates = new List<Anime>();
        var response = await GetUserAnimeRates(username);
        return response.Where(ar => string.Equals(ar.Status, status, StringComparison.InvariantCultureIgnoreCase)).ToList();
    }
    
    public static async Task<List<History>> GetUserHistory(string username)
    {
        var listAnimeRates = new List<History>();
        var userId = (await ShikimoriClient.Users.GetUser($"{username}")).Id;
        History[] response;
        var pages = 1;
        do
        {
            response = await ShikimoriClient.Users.GetHistory(userId, new HistoryRequestSettings{target_type = "Anime", limit = 100, page = pages});
            if (response.GetType() != typeof(History[]) && response.Length != 0) // working?
            {
                Console.WriteLine("some ex catched, retrying in 1 second");
                Thread.Sleep(1000);
                response = await ShikimoriClient.Users.GetHistory(userId, new HistoryRequestSettings{target_type = "Anime", limit = 100, page = pages});
            }

            listAnimeRates.AddRange(response ?? Array.Empty<History>());
            pages++;
        } while (response.Length != 0);
        
        return listAnimeRates.DistinctBy(a => a.Id).ToList();
    }
    public static async Task<List<long>> GetUserCompletedAnimesIdFromHistory(string username, int year)
    {
        var historyResponse = await GetUserHistory(username);
        var sortedHistory = historyResponse.Where(h => (h.Description.Contains("Просмотрено") 
                                                       || h.Description.Contains("Просмотрено и оценено")) 
                                                       && h.CreatedAt.Year == year).ToList();
        return sortedHistory.Select(h => h.Target.Id).ToList();
    }
    public static void PrintCompletedAnimesCount(string username, int year)
    {
        var response = GetUserCompletedAnimesIdFromHistory(username, year);
        var result = response.Result.Count();
        Console.WriteLine($"in {year} year you complete: {result} animes");
    }

    public async Task GetAnimeRatesPrint() // doens't work right
        {
            string? varYear = null;
            var year = 0;
            const string userId = "zaverk"; //TODO Console.ReadLine userId
            //var page = 1;
            uint titlesCounter = 0;
            uint kindCounterTv = 0;
            uint kindCounterSpecial = 0;
            uint kindCounterOva = 0;
            uint kindCounterOna = 0;
            uint kindCounterMovie = 0;
            uint kindCounterClip = 0;
    
            var listAnimeRates = await GetUserStatusAnimeRates(userId, "completed");
            var resultEnumerator = listAnimeRates.Where(r => r.CreatedAt?.Year == year).DistinctBy(r => r.Anime.Russian); 
            
            while (!int.TryParse(varYear, out year) || year < 2011)
            {
                Console.WriteLine("enter year (keep blank if you want overall result): ");
                if (year > 1 && year <= 2011)
                {
                    Console.WriteLine("must be greater than 2011!");
                }
    
                varYear = Console.ReadLine();
                Console.Clear();
                if (string.IsNullOrWhiteSpace(varYear))
                {
                    break;
                }
            }
            if (!string.IsNullOrWhiteSpace(varYear))
            {
                InSpecificYear(userId, year, listAnimeRates);
            }
            else
            {
                foreach (var item in listAnimeRates)
                {
                    titlesCounter++;
                    switch (item.Anime.Kind)
                    {
                        case "tv":
                            kindCounterTv++;
                            break;
                        case "special":
                            kindCounterSpecial++;
                            break;
                        case "ova":
                            kindCounterOva++;
                            break;
                        case "ona":
                            kindCounterOna++;
                            break;
                        case "movie":
                            kindCounterMovie++;
                            break;
                        case "clip":
                            kindCounterClip++;
                            break;
                    }
                }
                PrintResult(titlesCounter, kindCounterTv, kindCounterSpecial, kindCounterOva, kindCounterOna, kindCounterMovie, kindCounterClip);
            }
    
            void InSpecificYear(string? userid, int year, List<AnimeRate> listAnimeRates)
            {
                var resultInSpecificYear = listAnimeRates.Where(r => r.CreatedAt?.Year == year);
                foreach (var item in resultInSpecificYear)
                {
                    titlesCounter++;
                    switch (item.Anime.Kind)
                    {
                        case "tv":
                            kindCounterTv++;
                            break;
                        case "special":
                            kindCounterSpecial++;
                            break;
                        case "ova":
                            kindCounterOva++;
                            break;
                        case "ona":
                            kindCounterOna++;
                            break;
                        case "movie":
                            kindCounterMovie++;
                            break;
                        case "clip":
                            kindCounterClip++;
                            break;
                    }
                }
                PrintResult(titlesCounter, kindCounterTv, kindCounterSpecial, kindCounterOva, kindCounterOna, kindCounterMovie, kindCounterClip, year);
            }
        }
    private static void PrintResult(uint titlesCounter, uint kindCounterTv, uint kindCounterSpecial, uint kindCounterOva, uint kindCounterOna, uint kindCounterMovie, uint kindCounterClip)
        {
            if (titlesCounter == 0)
            {
                return;
            }

            Console.WriteLine("--- --- --- --- --- --- --- --- ---");
            Console.WriteLine($"За всё время просмотрено: {titlesCounter}");

            var sb = new StringBuilder("Из них: ");
            var firstStatement = true;

            void Appender(string toAppend, uint value)
            {
                if (value != 0)
                {
                    if (firstStatement)
                    {
                        firstStatement = false;
                    }
                    else
                    {
                        sb.Append(", ");
                    }

                    sb.Append(toAppend);
                    sb.Append(": ");
                    sb.Append(value);
                }
            }

            Appender("сериалов", kindCounterTv);
            Appender("фильмов", kindCounterMovie);
            Appender("спешелов", kindCounterSpecial);
            Appender("OVA", kindCounterOva);
            Appender("ONA", kindCounterOna);
            Appender("клипов", kindCounterClip);

            Console.WriteLine(sb);
            Console.WriteLine("--- --- --- --- --- --- --- --- ---");
        }
    private static void PrintResult(uint titlesCounter, uint kindCounterTv, uint kindCounterSpecial, uint kindCounterOva, uint kindCounterOna, uint kindCounterMovie, uint kindCounterClip, int year)
        {
            if (titlesCounter == 0)
            {
                return;
            }

            Console.WriteLine("--- --- --- --- --- --- --- --- ---");
            Console.WriteLine($"Просмотрено в {year} году: {titlesCounter}");

            var sb = new StringBuilder("Из них: ");
            var firstStatement = true;
            var appender = (string toAppend, uint value) =>
            {
                if (value != 0)
                {
                    if (firstStatement)
                    {
                        firstStatement = false;
                    }
                    else
                    {
                        sb.Append(", ");
                    }
                    sb.Append(toAppend);
                    sb.Append(": ");
                    sb.Append(value);
                }
            };

            appender("сериалов", kindCounterTv);
            appender("фильмов", kindCounterMovie);
            appender("спешелов", kindCounterSpecial);
            appender("OVA", kindCounterOva);
            appender("ONA", kindCounterOna);
            appender("клипов", kindCounterClip);

            Console.WriteLine(sb);
            Console.WriteLine("--- --- --- --- --- --- --- --- ---");
        }

    public async Task PrintHistoriesMatches(string username)
    {
        var count = 0;
        var userRates = await GetUserRates(username);
        var userHistory = await GetUserHistory(username);
        var targetIds = userRates.Select(ur => ur.TargetId).ToList();
        var result = new List<History>();
        foreach (var targetId in targetIds)
        {
            result.AddRange(userHistory.Where(h => (h.Target.Id == targetId && string.Equals(h.Description, "Просмотрено") || h.Description.StartsWith("Просмотрено и оценено на"))));
            count++;
        }

        foreach (var history in result) // 844
        {
            Console.WriteLine(history.Target.Russian + "||" + history.Description + "||" + history.CreatedAt);
        }
        
        Console.WriteLine("Всего: " + count);
    }
}
