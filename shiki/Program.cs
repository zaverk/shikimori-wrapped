using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using shiki.history_response.watched_in_specific_year;

namespace shiki
{
    public static class Program
    {
        public static async Task Main()
        {
            await HistoryController.WathedInHistory();
        }
    }
}