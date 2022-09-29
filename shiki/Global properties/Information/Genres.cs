using System.Threading.Tasks;
using shiki.Global_properties.Bases;
using shiki.Global_properties.Classes;
using shiki.Global_properties;
using Version = shiki.Global_properties.Bases.Version;

namespace shiki.Global_properties.Information
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