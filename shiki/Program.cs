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
        public static async Task WathedInHistory()
        {
            using var http_client = new HttpClient();
            string? userid = null;
            string? var_year = null;
            int year = 0;
            List<int> yearList = new() { 2011 };
            string? fewYears = null;
            while (string.IsNullOrWhiteSpace(userid))
            {
                Console.Write("enter your username: ");
                userid = Console.ReadLine();
            }

            while (string.IsNullOrWhiteSpace(fewYears) || (fewYears != "1" && fewYears != "2"))
            {
                Console.Clear();
                Console.WriteLine("check specific year?");
                Console.WriteLine("1 - yes, 2 - no");
                fewYears = Console.ReadLine();
            }

            Console.Clear();
            if (fewYears == "1") // brick?
            {
                while (string.IsNullOrWhiteSpace(var_year) || !int.TryParse(var_year, out year) || year < 2011)
                {
                    Console.Write("enter year: ");
                    if (year > 1 && year < 2011)
                    {
                        Console.WriteLine("input year must be great than 2011!");
                    }

                    var_year = Console.ReadLine();
                }

                yearList[0] = year;
                await temp(yearList);
            }
            else // brick?
            {
                int currentYear = DateTime.Now.Year;
                var tempYear = 2012;
                while (currentYear > 2011)
                {
                    yearList.Add(tempYear++);
                    currentYear--;
                }
            }

            async Task temp(List<int> yearList)
            {
                bool finished = false;
                uint page = 1;
                uint titles_counter = 0;
                uint kind_counter_TV = 0;
                uint kind_counter_Special = 0;
                uint kind_counter_OVA = 0;
                uint kind_counter_ONA = 0;
                uint kind_counter_Movie = 0;
                uint kind_counter_Clip = 0;
                while (!finished)
                {
                    for (int i = 0; i <= yearList.Count; i++) // brick
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

                        Console.Clear();
                        IEnumerable<History> result_enumerator = result.DistinctBy(r => r.Target.Russian);
                        foreach (History item in result_enumerator)
                        {
                            string name = item.Target.Russian;
                            string status = item.Description;
                            string? date = item.CreatedAt?.Date.ToString("d");
                            string kind = item.Target.Kind;
                            if (date == null)
                            {
                                finished = true;
                                break;
                            }

                            if (item.CreatedAt?.Year != yearList[i])
                            {
                                break;
                            }

                            if (status == "Просмотрено" || status.Contains("Просмотрено и оценено"))
                            {
                                titles_counter++;

                                if (kind == "tv")
                                {
                                    kind_counter_TV++;
                                }

                                if (kind == "special")
                                {
                                    kind_counter_Special++;
                                }

                                if (kind == "ova")
                                {
                                    kind_counter_OVA++;
                                }

                                if (kind == "ona")
                                {
                                    kind_counter_ONA++;
                                }

                                if (kind == "movie")
                                {
                                    kind_counter_Movie++;
                                }

                                if (kind == "clip")
                                {
                                    kind_counter_Clip++;
                                }
                            }

                            //Console.WriteLine($"Name: {name} || Date: {date}");
                        }

                        page++;
                        Console.WriteLine("--- --- --- --- --- --- --- --- ---");
                        Console.WriteLine($"Просмотрено в {yearList[i]} году: {titles_counter}");
                        Console.WriteLine($"Из них: сериалов: {kind_counter_TV}, фильмов: {kind_counter_Movie}, спешелов:   {kind_counter_Special}, OVA: {kind_counter_OVA}, ONA: {kind_counter_ONA}, клипов: {kind_counter_Clip}");
                    }

                }
                    
            }            
        }
        public static async Task Main()
        {
            await WathedInHistory();
        }
    }
}