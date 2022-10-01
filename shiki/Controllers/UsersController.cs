using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using ShikimoriSharp;
using shiki;
using ShikimoriSharp.Classes;

namespace shiki.Controllers
{
    internal class UsersController
    {
        public static async Task GetAnimeRates()
        {
            string? varYear = null;
            var year = 0;
            var userId = "zaverk"; //TODO Console.ReadLine userId
            //var page = 1;
            uint titlesCounter = 0;
            uint kindCounterTv = 0;
            uint kindCounterSpecial = 0;
            uint kindCounterOva = 0;
            uint kindCounterOna = 0;
            uint kindCounterMovie = 0;
            uint kindCounterClip = 0;

            //HttpClient https_client = new HttpClient();
            //HttpResponseMessage response = await https_client.GetAsync($"https://shikimori.one/api/users/{user_id}/anime_rates?limit=5000&status=completed&page={page}");
            ////check, if next pages is null or not
            //string json_response = await response.Content.ReadAsStringAsync();
            //List<User_anime_rates>? result = JsonConvert.DeserializeObject<List<User_anime_rates>>(json_response);
            ////for few pages, later

            var listAnimeRates = await Di.GetUserCompletedAnimeRates(userId);

            var resultEnumerator = listAnimeRates.Where(r => r.CreatedAt?.Year == year).DistinctBy(r => r.Anime.Russian);

            while (!int.TryParse(varYear, out year) || year < 2011) // refactor later
            {
                Console.WriteLine("enter year (keep blank if you want overall result): ");
                if (year > 1 && year <= 2011)
                {
                    Console.WriteLine("must be greater than 2011!");
                }

                varYear = Console.ReadLine();
                Console.Clear();
                if (string.IsNullOrWhiteSpace(varYear))
                {
                    break;
                }
            }
            if (!string.IsNullOrWhiteSpace(varYear))
            {
                InSpecificYear(userId, year, listAnimeRates);
            }
            else
            {
                foreach (var item in listAnimeRates)
                {
                    titlesCounter++;
                    switch (item.Anime.Kind)
                    {
                        case "tv":
                            kindCounterTv++;
                            break;
                        case "special":
                            kindCounterSpecial++;
                            break;
                        case "ova":
                            kindCounterOva++;
                            break;
                        case "ona":
                            kindCounterOna++;
                            break;
                        case "movie":
                            kindCounterMovie++;
                            break;
                        case "clip":
                            kindCounterClip++;
                            break;
                    }
                }
                PrintResult(titlesCounter, kindCounterTv, kindCounterSpecial, kindCounterOva, kindCounterOna, kindCounterMovie, kindCounterClip);
            }

            void InSpecificYear(string? userid, int year, List<AnimeRate> listAnimeRates)
            {
                var resultInSpecificYear = listAnimeRates.Where(r => r.CreatedAt?.Year == year);
                foreach (var item in resultInSpecificYear)
                {
                    titlesCounter++;
                    switch (item.Anime.Kind)
                    {
                        case "tv":
                            kindCounterTv++;
                            break;
                        case "special":
                            kindCounterSpecial++;
                            break;
                        case "ova":
                            kindCounterOva++;
                            break;
                        case "ona":
                            kindCounterOna++;
                            break;
                        case "movie":
                            kindCounterMovie++;
                            break;
                        case "clip":
                            kindCounterClip++;
                            break;
                    }
                }
                PrintResult(titlesCounter, kindCounterTv, kindCounterSpecial, kindCounterOva, kindCounterOna, kindCounterMovie, kindCounterClip, year);
            }
        }

        static void PrintResult(uint titlesCounter, uint kindCounterTv, uint kindCounterSpecial, uint kindCounterOva, uint kindCounterOna, uint kindCounterMovie, uint kindCounterClip)
        {
            if (titlesCounter == 0)
            {
                return;
            }

            Console.WriteLine("--- --- --- --- --- --- --- --- ---");
            Console.WriteLine($"За всё время просмотрено: {titlesCounter}");

            var sb = new StringBuilder("Из них: ");
            var firstStatement = true;

            void Appender(string toAppend, uint value)
            {
                if (value != 0)
                {
                    if (firstStatement)
                    {
                        firstStatement = false;
                    }
                    else
                    {
                        sb.Append(", ");
                    }

                    sb.Append(toAppend);
                    sb.Append(": ");
                    sb.Append(value);
                }
            }

            Appender("сериалов", kindCounterTv);
            Appender("фильмов", kindCounterMovie);
            Appender("спешелов", kindCounterSpecial);
            Appender("OVA", kindCounterOva);
            Appender("ONA", kindCounterOna);
            Appender("клипов", kindCounterClip);

            Console.WriteLine(sb);
            Console.WriteLine("--- --- --- --- --- --- --- --- ---");
        }

        static void PrintResult(uint titlesCounter, uint kindCounterTv, uint kindCounterSpecial, uint kindCounterOva, uint kindCounterOna, uint kindCounterMovie, uint kindCounterClip, int year)
        {
            if (titlesCounter == 0)
            {
                return;
            }

            Console.WriteLine("--- --- --- --- --- --- --- --- ---");
            Console.WriteLine($"Просмотрено в {year} году: {titlesCounter}");

            StringBuilder sb = new StringBuilder("Из них: ");
            bool firstStatement = true;
            var appender = (string toAppend, uint value) =>
            {
                if (value != 0)
                {
                    if (firstStatement)
                    {
                        firstStatement = false;
                    }
                    else
                    {
                        sb.Append(", ");
                    }
                    sb.Append(toAppend);
                    sb.Append(": ");
                    sb.Append(value);
                }
            };

            appender("сериалов", kindCounterTv);
            appender("фильмов", kindCounterMovie);
            appender("спешелов", kindCounterSpecial);
            appender("OVA", kindCounterOva);
            appender("ONA", kindCounterOna);
            appender("клипов", kindCounterClip);

            Console.WriteLine(sb);
            Console.WriteLine("--- --- --- --- --- --- --- --- ---");
        }
    }
}
