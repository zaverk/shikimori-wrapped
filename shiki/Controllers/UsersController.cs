using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using ShikimoriSharp;
using shiki;
using shiki.Services;
using ShikimoriSharp.Classes;
using ShikimoriSharp.Enums;

namespace shiki.Controllers
{
    public class UsersController
    {
        public static async Task<List<UserRate>> GetUserAnimeRatesInSpecificYear(int year, string username, MyList status)
        {
            var listAnimeRates = await UserServices.GetUserRates(username, status);
            return listAnimeRates.Where(r => r.CreatedAt?.Year == year).ToList();
        }
        public static async Task<List<UserRate>> GetUserAnimeRates(string username, MyList status)
        {
            return await UserServices.GetUserRates(username, status);
        }
    }
}
