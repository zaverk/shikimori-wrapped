// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Net;
// using Newtonsoft.Json;
//
// namespace shiki.Controllers
// {
//     public class HistoryController
//     {
//         public static async Task Watched()
//         {
//             #region initial and choice for specific year or not
//             var httpClient = new HttpClient();
//             string? userid = "zaverk";
//             
//             string? varYear = null;
//             int year = 0;
//             while (!int.TryParse(varYear, out year) || year < 2011) // refactor up to 40 later
//             {
//                 Console.WriteLine("enter year (keep blank if you want overall result): ");
//                 if (year > 1 && year < 2011)
//                 {
//                     Console.WriteLine("must be greater than 2011!");
//                 }
//
//                 varYear = Console.ReadLine();
//                 Console.Clear();
//                 if (string.IsNullOrWhiteSpace(varYear))
//                 {
//                     await Overall(httpClient, userid);
//                     break;
//                 }
//             }
//             
//             if (!string.IsNullOrWhiteSpace(varYear))
//             {
//                 await InSpecificYear(httpClient, userid, year);
//             }
//             #endregion
//             // i should exclude Overall? then i need to transfer GET from InSpecificYear
//             static async Task InSpecificYear(HttpClient httpClient, string? userid, int year)
//             {
//                 bool finished = false;
//                 uint page = 1;
//                 uint titlesCounter = 0;
//                 uint kindCounterTv = 0;
//                 uint kindCounterSpecial = 0;
//                 uint kindCounterOva = 0;
//                 uint kindCounterOna = 0;
//                 uint kindCounterMovie = 0;
//                 uint kindCounterClip = 0;
//                 while (!finished)
//                 {
//                     var response = await httpClient.GetAsync($"https://shikimori.one/api/users/{userid}/history?page={page}&limit=100&target_type=Anime");
//                     if (response.StatusCode != HttpStatusCode.OK)
//                     {
//                         continue;
//                     }
//
//                     string jsonResponse = await response.Content.ReadAsStringAsync();
//                     List<History>? result = JsonConvert.DeserializeObject<List<History>>(jsonResponse);
//                     if (result == null || result.Count == 0)
//                     {
//                         break;
//                     }
//
//                     IEnumerable<History> result_enumerator = result.Where(r => r.CreatedAt.Year == year).DistinctBy(r => r.Target.Russian);
//                     foreach (History item in result_enumerator)
//                     {
//                         string name = item.Target.Russian;
//                         string status = item.Description;
//                         string? date = item.CreatedAt.Date.ToString("d");
//                         string kind = item.Target.Kind;
//                         if (date == null)
//                         {
//                             finished = true;
//                             break;
//                         }
//
//                         if (status == "Просмотрено" || status.Contains("Просмотрено и оценено"))
//                         {
//                             titlesCounter++;
//                             switch (kind)
//                             {
//                                 case "tv":
//                                     kindCounterTv++;
//                                     break;
//                                 case "special":
//                                     kindCounterSpecial++;
//                                     break;
//                                 case "ova":
//                                     kindCounterOva++;
//                                     break;
//                                 case "ona":
//                                     kindCounterOna++;
//                                     break;
//                                 case "movie":
//                                     kindCounterMovie++;
//                                     break;
//                                 case "clip":
//                                     kindCounterClip++;
//                                     break;
//                             }
//
//                             Console.WriteLine($"Name: {name} || Date: {date} || Status: {status}");
//                         }
//                     }
//
//                     page++;
//                 }
//
//                 Console.WriteLine("--- --- --- --- --- --- --- --- ---"); // counter should not represent 0's
//                 Console.WriteLine($"Просмотрено в {year} году: {titlesCounter}");
//                 Console.WriteLine($"Из них: сериалов: {kindCounterTv}, фильмов: {kindCounterMovie}, спешелов: {kindCounterSpecial}, OVA: {kindCounterOva}, ONA: {kindCounterOna}, клипов: {kindCounterClip}");
//                 Console.WriteLine("--- --- --- --- --- --- --- --- ---");
//             }
//
//             static async Task Overall(HttpClient httpClientClient, string? userid)
//             {
//                 var finished = false;
//                 uint page = 1;
//                 uint titlesCounter = 0;
//                 uint kindCounterTv = 0;
//                 uint kindCounterSpecial = 0;
//                 uint kindCounterOva = 0;
//                 uint kindCounterOna = 0;
//                 uint kindCounterMovie = 0;
//                 uint kindCounterClip = 0;
//                 while (!finished)
//                 {
//                     HttpResponseMessage response = await httpClientClient.GetAsync($"https://shikimori.one/api/users/{userid}/history?page={page}&limit=100&target_type=Anime");
//                     if (response.StatusCode != HttpStatusCode.OK)
//                     {
//                         continue;
//                     }
//
//                     var jsonResponse = await response.Content.ReadAsStringAsync();
//                     List<History>? result = JsonConvert.DeserializeObject<List<History>>(jsonResponse);
//                     if (result == null || result.Count == 0)
//                     {
//                         break;
//                     }
//
//                     IEnumerable<History> resultEnumerator = result; //.DistinctBy(r => r.Target.Russian);
//                     foreach (History item in resultEnumerator)
//                     {
//                         string name = item.Target.Russian;
//                         string status = item.Description;
//                         string? date = item.CreatedAt.Date.ToString("d");
//                         string kind = item.Target.Kind;
//                         if (date == null)
//                         {
//                             finished = true;
//                             break;
//                         }
//                         
//                         if (status == "Просмотрено" || status.Contains("Просмотрено и оценено"))
//                         {
//                             titlesCounter++;
//                             switch (kind)
//                             {
//                                 case "tv":
//                                     kindCounterTv++;
//                                     break;
//                                 case "special":
//                                     kindCounterSpecial++;
//                                     break;
//                                 case "ova":
//                                     kindCounterOva++;
//                                     break;
//                                 case "ona":
//                                     kindCounterOna++;
//                                     break;
//                                 case "movie":
//                                     kindCounterMovie++;
//                                     break;
//                                 case "clip":
//                                     kindCounterClip++;
//                                     break;
//                             }
//
//                             Console.WriteLine($"Name: {name} || Date: {date}");
//                         }
//                     }
//
//                     page++;
//                 }
//
//                 Console.WriteLine("--- --- --- --- --- --- --- --- ---"); // counter should not represent 0's
//                 Console.WriteLine($"Просмотрено всего: {titlesCounter}");
//                 Console.WriteLine($"Из них: сериалов: {kindCounterTv}, фильмов: {kindCounterMovie}, спешелов: {kindCounterSpecial}, OVA: {kindCounterOva}, ONA: {kindCounterOna}, клипов: {kindCounterClip}");
//                 Console.WriteLine("--- --- --- --- --- --- --- --- ---");
//             }
//         }
//     }
// }
