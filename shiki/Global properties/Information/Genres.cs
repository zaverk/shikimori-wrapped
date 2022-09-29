using System.Threading.Tasks;
using shiki.Global_properties.Bases;
using shiki.Global_properties.Classes;

namespace ShikimoriSharp.Information
{
    public class Genres : ApiBase
    {
        public Genres(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Genre[]> GetGenres()
        {
            return await Request<Genre[]>("genres");
        }
    }
}