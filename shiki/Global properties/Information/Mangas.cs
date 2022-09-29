using System.Threading.Tasks;
using ShikimoriSharp.AdditionalRequests;
using shiki.Global_properties.Bases;
using shiki.Global_properties.Classes;
using ShikimoriSharp.Settings;

namespace ShikimoriSharp.Information
{
    public class Mangas : MangaRanobeApiBase
    {
        public Mangas(ApiClient apiClient) : base("mangas", apiClient)
        {
        }
    }
}