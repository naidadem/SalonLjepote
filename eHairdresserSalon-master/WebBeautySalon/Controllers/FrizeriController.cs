using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using eHairdresserSalon_API.Models;
using Microsoft.AspNetCore.Mvc;
using WebBeautySalon.Models;
using WebBeautySalon.Util;

namespace WebBeautySalon.Controllers
{
    public class FrizeriController : Controller
    {
        private WebAPIHelper frizeri = new WebAPIHelper(Global.APIAddress, "api/Frizeri");

        List<Frizeri_Result> sviFrizeri = new List<Frizeri_Result>();

        public IActionResult Prikazi()
        {

            HttpResponseMessage responseAkcije = frizeri.GetResponse();
            if (responseAkcije.IsSuccessStatusCode)
            {
                sviFrizeri = responseAkcije.Content.ReadAsAsync<List<Frizeri_Result>>().Result;
            }

            ViewData["datas"] = sviFrizeri;


            return View(sviFrizeri);
        }
      
    }
}