using MongoDB.Driver;
using shiki.Models;
using ShikimoriSharp.Classes;
using Anime = shiki.Models.Anime;

namespace shiki.Repository;

public interface IDbRepo
{
    Task AddUserAnimeRates(string username, List<AnimeRate> list);
    Task<List<AnimeRate>> GetUserAnimeRates(string username);
    Task AddUserAnime();
    Task<List<Anime>> GetUserAnime();
    Task AddUserHistory();
    Task<List<History[]>> GetUserHistory();

    Task AddAnime();
    Task<List<Anime>> GetAnime();
}