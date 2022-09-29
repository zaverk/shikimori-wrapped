using System.Threading.Tasks;
using ShikimoriSharp.AdditionalRequests;
using shiki.Global_properties.Bases;

namespace ShikimoriSharp.Information
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