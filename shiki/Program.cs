using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace shiki
{
    public static class Program
    {
        public static async Task Main()
        {
            using var http_client = new HttpClient();
            string? userid = null;
            while (string.IsNullOrEmpty(userid))
            {
                userid = Console.ReadLine();
            }

            bool finished = false;
            uint page = 1;
            uint titles_counter = 0;
            while (!finished)
            {
                HttpResponseMessage response = await http_client.GetAsync($"https://shikimori.one/api/users/{userid}/history?page={page}&limit=100&target_type=Anime");

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    continue;
                }

                string json_response = await response.Content.ReadAsStringAsync();
                List<History>? result = JsonConvert.DeserializeObject<List<History>>(json_response);

                if (result == null || result.Count == 0)
                {
                    break;
                }

                IEnumerable<History> result_enumerator = result.DistinctBy(r => r.Target.Russian);
                foreach (History item in result_enumerator)
                {
                    string name = item.Target.Russian;
                    string status = item.Description;
                    string? date = item.CreatedAt?.Date.ToString("d");
                    if (date == null)
                    {
                        finished = true;
                        break;
                    }

                    if (item.CreatedAt?.Year.ToString() != DateTime.Now.Year.ToString())
                    {
                        break;
                    }

                    if (status == "Просмотрено" || status.Contains("Просмотрено и оценено"))
                    {
                        titles_counter++;
                    }

                    Console.WriteLine($"Name: {name} ||Date: {date} ||Status: {status}");
                }

                page++;
            }

            Console.WriteLine($"Просмотрено в этом году: {titles_counter}");
        }
    }
}


//foreach (History item in response)
//{
//    else if (dublicate)
//    {
//        check if it's rewatched => int rewatched_at_past_year++;
//        continue;
//    }
//}
