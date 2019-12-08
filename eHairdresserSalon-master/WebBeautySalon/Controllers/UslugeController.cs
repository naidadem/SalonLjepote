using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using eHairdresserSalon_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBeautySalon.Util;

namespace WebBeautySalon.Controllers
{
    public class UslugeController : Controller
    {
        private WebAPIHelper uslugeService = new WebAPIHelper(Global.APIAddress, "api/Usluge");

        List<Usluge_Result> usluge = new List<Usluge_Result>();

        public IActionResult Index(int vrstaId = 1)
        {
            HttpResponseMessage responseUsluge = uslugeService.GetActionResponse("SearchByVrstaUsluge", vrstaId.ToString());
            if (responseUsluge.IsSuccessStatusCode)
            {
                usluge.Clear();
                usluge = responseUsluge.Content.ReadAsAsync<List<Usluge_Result>>().Result;
            }

            ViewData["vrste"] = Global.vrste;
            ViewData["odabranaVrsta"] = vrstaId;
            return View(usluge);
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}