using System.Threading.Tasks;
using shiki.Global_properties;
using shiki.Global_properties.Bases;
using shiki.Global_properties.Classes;
using Version = shiki.Global_properties.Bases.Version;

namespace shiki.Global_properties.Information
{
    public class Calendars : ApiBase
    {
        public Calendars(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Calendar[]> GetCalendar()
        {
            return await Request<Calendar[]>("calendar");
        }
    }
}