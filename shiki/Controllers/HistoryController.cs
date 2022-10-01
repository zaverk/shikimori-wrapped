//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using Newtonsoft.Json;
//using shiki.Global_properties.Classes;

//namespace shiki.Controllers
//{
//    public class HistoryController
//    {
//        public static async Task Watched()
//        {
//            #region initial and choice for specific year or not
//            var http_client = new HttpClient();
//            string? userid = "zaverk";
            
//            string? var_year = null;
//            int year = 0;
//            while (!int.TryParse(var_year, out year) || year < 2011) // refactor up to 40 later
//            {
//                Console.WriteLine("enter year (keep blank if you want overall result): ");
//                if (year > 1 && year < 2011)
//                {
//                    Console.WriteLine("must be greater than 2011!");
//                }

//                var_year = Console.ReadLine();
//                Console.Clear();
//                if (string.IsNullOrWhiteSpace(var_year))
//                {
//                    await Overall(http_client, userid);
//                    break;
//                }
//            }
            
//            if (!string.IsNullOrWhiteSpace(var_year))
//            {
//                await InSpecificYear(http_client, userid, year);
//            }
//            #endregion
//            // i should exclude Overall? then i need to transfer GET from InSpecificYear
//            static async Task InSpecificYear(HttpClient http_client, string? userid, int year)
//            {
//                bool finished = false;
//                uint page = 1;
//                uint titles_counter = 0;
//                uint kind_counter_TV = 0;
//                uint kind_counter_Special = 0;
//                uint kind_counter_OVA = 0;
//                uint kind_counter_ONA = 0;
//                uint kind_counter_Movie = 0;
//                uint kind_counter_Clip = 0;
//                while (!finished)
//                {
//                    HttpResponseMessage response = await http_client.GetAsync($"https://shikimori.one/api/users/{userid}/history?page={page}&limit=100&target_type=Anime");
//                    if (response.StatusCode != HttpStatusCode.OK)
//                    {
//                        continue;
//                    }

//                    string json_response = await response.Content.ReadAsStringAsync();
//                    List<History>? result = JsonConvert.DeserializeObject<List<History>>(json_response);
//                    if (result == null || result.Count == 0)
//                    {
//                        break;
//                    }

//                    IEnumerable<History> result_enumerator = result.Where(r => r.CreatedAt.Year == year).DistinctBy(r => r.Target.Russian);
//                    foreach (History item in result_enumerator)
//                    {
//                        string name = item.Target.Russian;
//                        string status = item.Description;
//                        string? date = item.CreatedAt.Date.ToString("d");
//                        string kind = item.Target.Kind;
//                        if (date == null)
//                        {
//                            finished = true;
//                            break;
//                        }

//                        if (status == "Просмотрено" || status.Contains("Просмотрено и оценено"))
//                        {
//                            titles_counter++;
//                            switch (kind)
//                            {
//                                case "tv":
//                                    kind_counter_TV++;
//                                    break;
//                                case "special":
//                                    kind_counter_Special++;
//                                    break;
//                                case "ova":
//                                    kind_counter_OVA++;
//                                    break;
//                                case "ona":
//                                    kind_counter_ONA++;
//                                    break;
//                                case "movie":
//                                    kind_counter_Movie++;
//                                    break;
//                                case "clip":
//                                    kind_counter_Clip++;
//                                    break;
//                            }

//                            Console.WriteLine($"Name: {name} || Date: {date} || Status: {status}");
//                        }
//                    }

//                    page++;
//                }

//                Console.WriteLine("--- --- --- --- --- --- --- --- ---"); // counter should not represent 0's
//                Console.WriteLine($"Просмотрено в {year} году: {titles_counter}");
//                Console.WriteLine($"Из них: сериалов: {kind_counter_TV}, фильмов: {kind_counter_Movie}, спешелов: {kind_counter_Special}, OVA: {kind_counter_OVA}, ONA: {kind_counter_ONA}, клипов: {kind_counter_Clip}");
//                Console.WriteLine("--- --- --- --- --- --- --- --- ---");
//            }

//            static async Task Overall(HttpClient http_client, string? userid)
//            {
//                bool finished = false;
//                uint page = 1;
//                uint titles_counter = 0;
//                uint kind_counter_TV = 0;
//                uint kind_counter_Special = 0;
//                uint kind_counter_OVA = 0;
//                uint kind_counter_ONA = 0;
//                uint kind_counter_Movie = 0;
//                uint kind_counter_Clip = 0;
//                while (!finished)
//                {
//                    HttpResponseMessage response = await http_client.GetAsync($"https://shikimori.one/api/users/{userid}/history?page={page}&limit=100&target_type=Anime");
//                    if (response.StatusCode != HttpStatusCode.OK)
//                    {
//                        continue;
//                    }

//                    string json_response = await response.Content.ReadAsStringAsync();
//                    List<History>? result = JsonConvert.DeserializeObject<List<History>>(json_response);
//                    if (result == null || result.Count == 0)
//                    {
//                        break;
//                    }

//                    IEnumerable<History> result_enumerator = result; //.DistinctBy(r => r.Target.Russian);
//                    foreach (History item in result_enumerator)
//                    {
//                        string name = item.Target.Russian;
//                        string status = item.Description;
//                        string? date = item.CreatedAt.Date.ToString("d");
//                        string kind = item.Target.Kind;
//                        if (date == null)
//                        {
//                            finished = true;
//                            break;
//                        }
                        
//                        if (status == "Просмотрено" || status.Contains("Просмотрено и оценено"))
//                        {
//                            titles_counter++;
//                            switch (kind)
//                            {
//                                case "tv":
//                                    kind_counter_TV++;
//                                    break;
//                                case "special":
//                                    kind_counter_Special++;
//                                    break;
//                                case "ova":
//                                    kind_counter_OVA++;
//                                    break;
//                                case "ona":
//                                    kind_counter_ONA++;
//                                    break;
//                                case "movie":
//                                    kind_counter_Movie++;
//                                    break;
//                                case "clip":
//                                    kind_counter_Clip++;
//                                    break;
//                            }

//                            Console.WriteLine($"Name: {name} || Date: {date}");
//                        }
//                    }

//                    page++;
//                }

//                Console.WriteLine("--- --- --- --- --- --- --- --- ---"); // counter should not represent 0's
//                Console.WriteLine($"Просмотрено всего: {titles_counter}");
//                Console.WriteLine($"Из них: сериалов: {kind_counter_TV}, фильмов: {kind_counter_Movie}, спешелов: {kind_counter_Special}, OVA: {kind_counter_OVA}, ONA: {kind_counter_ONA}, клипов: {kind_counter_Clip}");
//                Console.WriteLine("--- --- --- --- --- --- --- --- ---");
//            }
//        }
//    }
//}
