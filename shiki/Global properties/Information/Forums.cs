using System.Threading.Tasks;
using shiki.Global_properties;
using shiki.Global_properties.AdditionalRequests;
using shiki.Global_properties.Bases;
using Version = shiki.Global_properties.Bases.Version;

namespace shiki.Global_properties.Information
{
    public class Forums : ApiBase
    {
        public Forums(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Forum[]> GetForums(AccessToken personalInformation = null)
        {
            return await Request<Forum[]>("forums", personalInformation);
        }
    }
}