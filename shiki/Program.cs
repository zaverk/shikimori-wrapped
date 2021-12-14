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
            var json_data = string.Empty;
            string? userid = Console.ReadLine();
            bool s = true;
            int q = 0; // will not be used
            int e = 0;
            // attempt to download JSON data as a string
            for (int i = 1; s == true; i++)
            {
                try
                {
                    json_data = w.DownloadString($"https://shikimori.one/api/users/{userid}/history?page={i}&limit=100&target_type=Anime");
                    List<Response> response = JsonConvert.DeserializeObject<List<Response>>(json_data);
                   if (json_data == null)
                   {
                       s = false;
                   }
                   foreach (Response item in response)
                   {
                        string name = item.Target.Russian;
                        string status = item.Description;
                        string date = item.CreatedAt?.Date.ToString("d");
                        if (item.CreatedAt?.Year.ToString() != DateTime.Now.Year.ToString())
                        {
                            break;
                        }
                        if (status == "Просмотрено" || status.Contains("Просмотрено и оценено"))
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
