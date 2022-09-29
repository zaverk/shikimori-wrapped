using System.Threading.Tasks;
using shiki.Global_properties.Bases;
using Version = shiki.Global_properties.Bases.Version;

namespace shiki.Global_properties.UpdatableInformation
{
    public class TopicIgnores : ApiBase
    {
        public TopicIgnores(ApiClient apiClient) : base(Version.v2, apiClient)
        {
        }

        public async Task Ignore(int id, AccessToken personalInformation)
        {
            Requires(personalInformation, new[] {"ignores"});
            await NoResponseRequest($"topics/{id}/ignore", personalInformation);
        }

        public async Task UnIgnore(int id, AccessToken personalInformation)
        {
            Requires(personalInformation, new[] {"ignores"});
            await NoResponseRequest($"topics/{id}/ignore", personalInformation, method: "DELETE");
        }
    }
}