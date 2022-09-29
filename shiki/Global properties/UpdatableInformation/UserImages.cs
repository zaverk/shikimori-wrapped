using System.Threading.Tasks;
using shiki.Global_properties.Bases;
using shiki.Global_properties.Classes;
using shiki.Global_properties.Settings;
using Version = shiki.Global_properties.Bases.Version;

namespace shiki.Global_properties.UpdatableInformation
{
    public class UserImages : ApiBase
    {
        public UserImages(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<ResultImage> CreateUserImage(UserImagesSettings settings, AccessToken personalInformation)
        {
            Requires(personalInformation, new[] {"comments"});
            return await Request<ResultImage, UserImagesSettings>("user_images", settings, personalInformation, "POST");
        }
    }
}