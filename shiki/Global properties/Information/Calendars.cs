using System.Threading.Tasks;
using shiki.Global_properties.Bases;
using shiki.Global_properties.Classes;

namespace ShikimoriSharp.Information
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