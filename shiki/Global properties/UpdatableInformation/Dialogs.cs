using System.Threading.Tasks;
using shiki.Global_properties.Bases;
using shiki.Global_properties.Classes;
using Version = shiki.Global_properties.Bases.Version;

namespace shiki.Global_properties.UpdatableInformation
{
    public class Dialogs : ApiBase
    {
        public Dialogs(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Dialog[]> GetDialogs(AccessToken personalInformation)
        {
            Requires(personalInformation, new[] {"messages"});
            return await Request<Dialog[]>("dialogs", personalInformation);
        }
        public async Task<Message[]> GetDialogs(string fromNickname, AccessToken personalInformation)
        {
            Requires(personalInformation, new[] {"messages"});
            return await Request<Message[]>($"dialogs/{fromNickname}", personalInformation);
        }

        public async Task DeleteDialog(string nickname, AccessToken personalInformation)
        {
            Requires(personalInformation, new[] {"messages"});
            await NoResponseRequest($"dialogs/{nickname}", personalInformation, method: "DELETE");
        }
    }
}