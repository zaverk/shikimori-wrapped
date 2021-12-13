using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace shiki
{
    public class Program
    {
        public string Created_at { get; set; }
        public static void Main()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                string? userid = Console.ReadLine();
                bool s = true;
                string currentyear = DateTime.Now.Year.ToString();
                int q = 0;
                int e = 0;
                // attempt to download JSON data as a string
                for (int i = 1; s == true; i++)
                {
                    try
                    {
                        json_data = w.DownloadString($"https://shikimori.one/api/users/{userid}/history?page={i}&limit=100&target_type=Anime");
                        if (json_data == null || json_data == "[]")
                        {
                            s = false;
                            break;
                        }
                        var response = JArray.Parse(json_data);
                        foreach (JObject item in response)
                        {
                            string name = item.GetValue("target").ElementAt(2).First().ToString();
                            string date = DateTime.Parse(item.GetValue("created_at").ToString()).Year.ToString();
                            if (date != currentyear)
                            {
                                break;
                            }
                            string status = item.GetValue("description").ToString();
                            if (status == "Просмотрено" || status.Contains("Просмотрено и оценено"))
                            {
                                Console.WriteLine($"Name: {name} Date: {date} Status: {status}");
                                e++;
                            }
                            q++;
                        }
                    }
                    catch (Exception)
                    {
                        s = false;
                    }
                }
                Console.WriteLine($"Всего иттераций: {q} Просмотрено: {e}");
            }
        }
    }
}