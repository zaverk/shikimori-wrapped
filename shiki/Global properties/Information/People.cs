using System.Threading.Tasks;
using shiki.Global_properties.Bases;
using shiki.Global_properties.Classes;
using shiki.Global_properties;
using Version = shiki.Global_properties.Bases.Version;

namespace shiki.Global_properties.Information
{
    public class People : ApiBase
    {
        public People(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<SearchPerson[]> GetPerson(Search settings)
        {
            return await Request<SearchPerson[], Search>("people/search", settings);
        }

        public async Task<Person> GetPerson(long id, AccessToken personalInformation = null)
        {
            return await Request<Person>($"people/{id}", personalInformation);
        }
    }
}