using System.Threading.Tasks;
using shiki.Global_properties;
using shiki.Global_properties.Bases;
using shiki.Global_properties.Classes;
using Version = shiki.Global_properties.Bases.Version;

namespace shiki.Global_properties.Information
{
    public class Studios : ApiBase
    {
        public Studios(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Studio[]> GetStudios()
        {
            return await Request<Studio[]>("studios");
        }
    }
}