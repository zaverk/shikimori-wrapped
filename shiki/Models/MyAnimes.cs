using ShikimoriSharp;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shiki.Models
{
    public class MyAnimes : Animes
    {
        public MyAnimes(ApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<MyAnimeID> GetAnime1(long id, AccessToken personalInformation = null)
        {
            return await Request<MyAnimeID>($"animes/{id}", personalInformation);
        }
    }
}
