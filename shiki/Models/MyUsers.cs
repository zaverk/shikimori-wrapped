using ShikimoriSharp;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Classes;
using ShikimoriSharp.Information;
using ShikimoriSharp.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shiki.Models
{
    public class MyUsers : Users
    {
        public MyUsers(ApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<AnimeRate[]> GetUserAnimeRates(long id, AnimeRateRequestWithStatusSettings settings, AccessToken personalInformation = null)
        {
            return await AllRates("anime", id, settings, personalInformation);
        }
        
        private async Task<AnimeRate[]> AllRates(string thingy, long id, AnimeRateRequestWithStatusSettings settings, AccessToken p)
        {
            return await Request<AnimeRate[], AnimeRateRequestSettings>($"users/{id}/{thingy}_rates", settings, p);
        }
    }
}
