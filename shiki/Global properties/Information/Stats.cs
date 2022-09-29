using System.Threading.Tasks;
using shiki.Global_properties.Bases;
using Version = shiki.Global_properties.Bases.Version;


namespace shiki.Global_properties.Information
{
    public class Stats : ApiBase
    {
        public Stats(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        /// <summary>
        ///     Be careful of this function. The estimated time of execution is very high
        /// </summary>
        public async Task<int[]> GetActiveUsers()
        {
            return await Request<int[]>("stats/active_users");
        }
    }
}