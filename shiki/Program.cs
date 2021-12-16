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
    public class Program
    {
        public static void Main()
        {
            using var w = new WebClient();
            string? userid = Console.ReadLine();
            bool s = true;
            int q = 0; // will not be used
            int e = 0;
            // attempt to download JSON data as a string
            for (int i = 1; s == true; i++)
            {
                try
                {
                    string json_data = w.DownloadString($"https://shikimori.one/api/users/{userid}/history?page={i}&limit=100&target_type=Anime");
                    List<History> res = JsonConvert.DeserializeObject<List<History>>(json_data);
                    IEnumerable<History> responce = res.DistinctBy(r => r.Target.Russian);
                    if (json_data == null)
                   {
                       s = false;
                   }
                   foreach (History item in responce)
                   {
                        string name = item.Target.Russian;
                        string status = item.Description;
                        string date = item.CreatedAt?.Date.ToString("d");
                        if (item.CreatedAt?.Year.ToString() != DateTime.Now.Year.ToString())
                        {
                            break;
                        }
                        if (status == "Просмотрено" || status.Contains("Просмотрено и оценено" ))
                        {
                            e++;
                        }
                        q++;
                           Console.WriteLine($"Name: {name} ||Date: {date} ||Status: {status}");
                   }
                }
                catch (Exception)
                {
                    Console.WriteLine("Done");
                    s = false;
                }
            }
            Console.WriteLine($"Всего иттераций: {q} Просмотрено в этом году: {e}");
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
