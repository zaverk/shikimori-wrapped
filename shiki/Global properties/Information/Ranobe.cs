using System.Threading.Tasks;
using shiki.Global_properties.AdditionalRequests;
using shiki.Global_properties.Bases;
using shiki.Global_properties.Classes;
using shiki.Global_properties.Settings;
using shiki.Global_properties;
using Version = shiki.Global_properties.Bases.Version;

namespace shiki.Global_properties.Information
{
    public class Ranobe : MangaRanobeApiBase
    {
        public Ranobe(ApiClient apiClient) : base("ranobe", apiClient)
        {
        }
    }
}