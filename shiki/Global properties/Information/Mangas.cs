using System.Threading.Tasks;
using shiki.Global_properties.AdditionalRequests;
using shiki.Global_properties.Bases;
using shiki.Global_properties.Classes;
using shiki.Global_properties.Settings;

namespace shiki.Global_properties.Information
{
    public class Mangas : MangaRanobeApiBase
    {
        public Mangas(ApiClient apiClient) : base("mangas", apiClient)
        {
        }
    }
}