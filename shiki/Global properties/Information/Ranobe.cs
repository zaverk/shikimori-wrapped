using System.Threading.Tasks;
using ShikimoriSharp.AdditionalRequests;
using shiki.Global_properties.Bases;
using shiki.Global_properties.Classes;
using ShikimoriSharp.Settings;

namespace ShikimoriSharp.Information
{
    public class Ranobe : MangaRanobeApiBase
    {
        public Ranobe(ApiClient apiClient) : base("ranobe", apiClient)
        {
        }
    }
}