using System.Threading.Tasks;
using shiki.Global_properties;
using shiki.Global_properties.Bases;
using shiki.Global_properties.Classes;
using Version = shiki.Global_properties.Bases.Version;

namespace shiki.Global_properties.Information
{
    public class Characters : ApiBase
    {
        public Characters(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Character[]> GetCharactersBySearch(string search)
        {
            return await Request<Character[], Search>("characters/search", new Search {search = search});
        }

        public async Task<FullCharacter> GetCharacterById(long id, AccessToken personalInformation = null)
        {
            return await Request<FullCharacter>($"characters/{id}", personalInformation);
        }
    }
}