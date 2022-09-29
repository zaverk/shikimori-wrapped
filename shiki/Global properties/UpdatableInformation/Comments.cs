using System.Threading.Tasks;
using shiki.Global_properties.Bases;
using shiki.Global_properties.Classes;
using shiki.Global_properties.Settings;
using Version = shiki.Global_properties.Bases.Version;

namespace shiki.Global_properties.UpdatableInformation
{
    public class Comments : ApiBase
    {
        public Comments(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Comment> GetComment(long id, AccessToken personalInformation = null)
        {
            return await Request<Comment>($"comments/{id}", personalInformation);
        }

        public async Task<Comment[]> GetComments(CommentsRequestSettings settings, AccessToken personalInformation = null)
        {
            return await Request<Comment[], CommentsRequestSettings>("comments", settings, personalInformation);
        }

        public async Task<Comment> SendComment(CommentCreateSettings settings, AccessToken personalInformation)
        {
            Requires(personalInformation, new[] {"comments"});
            return await SendJson<Comment>("comments", settings, personalInformation);
        }

        public async Task<Comment> EditComment(long id, CommentEditSettings newMessage, AccessToken personalInformation)
        {
            Requires(personalInformation, new[] {"comments"});
            return await SendJson<Comment>($"comments/{id}", newMessage, personalInformation, "PUT");
        }

        public async Task DeleteComment(long id, AccessToken personalInformation)
        {
            Requires(personalInformation, new[] {"comments"});
            await NoResponseRequest($"comment/{id}", true, personalInformation, "DELETE");
        }
    }
}