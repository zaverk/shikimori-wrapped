using System.Threading.Tasks;
using shiki.Global_properties.Bases;
using shiki.Global_properties.Classes;

namespace ShikimoriSharp.Information
{
    public class Bans : ApiBase
    {
        public Bans(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Ban[]> GetBans()
        {
            return await Request<Ban[]>("bans");
        }
    }
}