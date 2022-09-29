﻿using System;
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
            string? var_year = null;
            int year = 0;
            string user_id = "zaverk";
            var page = 1;
            uint titles_counter = 0;
            uint kind_counter_TV = 0;
            uint kind_counter_Special = 0;
            uint kind_counter_OVA = 0;
            uint kind_counter_ONA = 0;
            uint kind_counter_Movie = 0;
            uint kind_counter_Clip = 0;

            //HttpClient https_client = new HttpClient();
            //HttpResponseMessage response = await https_client.GetAsync($"https://shikimori.one/api/users/{user_id}/anime_rates?limit=5000&status=completed&page={page}");
            ////check, if next pages is null or not
            //string json_response = await response.Content.ReadAsStringAsync();
            //List<User_anime_rates>? result = JsonConvert.DeserializeObject<List<User_anime_rates>>(json_response);
            ////for few pages, later

            List<AnimeRate> ListAnimeRates = await DI.MyGetUserAnimeRates(user_id);

            IEnumerable<AnimeRate> result_enumerator = ListAnimeRates.Where(r => r.CreatedAt?.Year == year).DistinctBy(r => r.Anime.Russian);

            while (!int.TryParse(var_year, out year) || year < 2011) // refactor later
            {
                Console.WriteLine("enter year (keep blank if you want overall result): ");
                if (year > 1 && year <= 2011)
                {
                    Console.WriteLine("must be greater than 2011!");
                }

                var_year = Console.ReadLine();
                Console.Clear();
                if (string.IsNullOrWhiteSpace(var_year))
                {
                    break;
                }
            }
            if (!string.IsNullOrWhiteSpace(var_year))
            {
                InSpecificYear(user_id, year, ListAnimeRates);
            }
            else
            {
                foreach (var item in ListAnimeRates)
                {
                    titles_counter++;
                    switch (item.Anime.Kind)
                    {
                        case "tv":
                            kind_counter_TV++;
                            break;
                        case "special":
                            kind_counter_Special++;
                            break;
                        case "ova":
                            kind_counter_OVA++;
                            break;
                        case "ona":
                            kind_counter_ONA++;
                            break;
                        case "movie":
                            kind_counter_Movie++;
                            break;
                        case "clip":
                            kind_counter_Clip++;
                            break;
                    }
                }
                PrintResult(titles_counter, kind_counter_TV, kind_counter_Special, kind_counter_OVA, kind_counter_ONA, kind_counter_Movie, kind_counter_Clip);
            }

            void InSpecificYear(string? userid, int year, List<AnimeRate> ListAnimeRates)
            {
                IEnumerable<AnimeRate> result_InSpecificYear = ListAnimeRates.Where(r => r.CreatedAt?.Year == year);
                foreach (var item in result_InSpecificYear)
                {
                    titles_counter++;
                    switch (item.Anime.Kind)
                    {
                        case "tv":
                            kind_counter_TV++;
                            break;
                        case "special":
                            kind_counter_Special++;
                            break;
                        case "ova":
                            kind_counter_OVA++;
                            break;
                        case "ona":
                            kind_counter_ONA++;
                            break;
                        case "movie":
                            kind_counter_Movie++;
                            break;
                        case "clip":
                            kind_counter_Clip++;
                            break;
                    }
                }
                PrintResult(titles_counter, kind_counter_TV, kind_counter_Special, kind_counter_OVA, kind_counter_ONA, kind_counter_Movie, kind_counter_Clip, year);
            }
        }

        static void PrintResult(uint titles_counter, uint kind_counter_TV, uint kind_counter_Special, uint kind_counter_OVA, uint kind_counter_ONA, uint kind_counter_Movie, uint kind_counter_Clip)
        {
            if (titles_counter == 0)
            {
                return;
            }

            Console.WriteLine("--- --- --- --- --- --- --- --- ---");
            Console.WriteLine($"За всё время просмотрено: {titles_counter}");

            StringBuilder sb = new StringBuilder("Из них: ");
            bool first_statement = true;
            var appender = (string to_append, uint value) =>
            {
                if (value != 0)
                {
                    if (first_statement)
                    {
                        first_statement = false;
                    }
                    else
                    {
                        sb.Append(", ");
                    }
                    sb.Append(to_append);
                    sb.Append(": ");
                    sb.Append(value);
                }
            };

            appender("сериалов", kind_counter_TV);
            appender("фильмов", kind_counter_Movie);
            appender("спешелов", kind_counter_Special);
            appender("OVA", kind_counter_OVA);
            appender("ONA", kind_counter_ONA);
            appender("клипов", kind_counter_Clip);

            Console.WriteLine(sb);
            Console.WriteLine("--- --- --- --- --- --- --- --- ---");
        }

        static void PrintResult(uint titles_counter, uint kind_counter_TV, uint kind_counter_Special, uint kind_counter_OVA, uint kind_counter_ONA, uint kind_counter_Movie, uint kind_counter_Clip, int year)
        {
            if (titles_counter == 0)
            {
                return;
            }

            Console.WriteLine("--- --- --- --- --- --- --- --- ---");
            Console.WriteLine($"Просмотрено в {year} году: {titles_counter}");

            StringBuilder sb = new StringBuilder("Из них: ");
            bool first_statement = true;
            var appender = (string to_append, uint value) =>
            {
                if (value != 0)
                {
                    if (first_statement)
                    {
                        first_statement = false;
                    }
                    else
                    {
                        sb.Append(", ");
                    }
                    sb.Append(to_append);
                    sb.Append(": ");
                    sb.Append(value);
                }
            };

            appender("сериалов", kind_counter_TV);
            appender("фильмов", kind_counter_Movie);
            appender("спешелов", kind_counter_Special);
            appender("OVA", kind_counter_OVA);
            appender("ONA", kind_counter_ONA);
            appender("клипов", kind_counter_Clip);

            Console.WriteLine(sb);
            Console.WriteLine("--- --- --- --- --- --- --- --- ---");
        }
    }
}
