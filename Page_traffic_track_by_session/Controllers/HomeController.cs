using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Page_traffic_track_by_session.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Page_traffic_track_by_session.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Comingfrompage") == null) { HttpContext.Session.SetInt32("Comingfrompage", 0); }
            if (HttpContext.Session.GetString("coming_from_page") == null) { HttpContext.Session.SetString("coming_from_page", "You came from outside"); }
            ViewBag.Comingfrompage = HttpContext.Session.GetInt32("Comingfrompage");
            ViewBag.Nameofpreviouspage = HttpContext.Session.GetString("coming_from_page");
            HttpContext.Session.SetString("Greeting", "Merhaba");
            ViewBag.Greetingmessage = HttpContext.Session.GetString("Greeting");
           
            return View();
        }


        // [HttpPost]
        public void Changecomingfrompageinfo(string jumpedfrompagename)
        {


            if (jumpedfrompagename == "index") { HttpContext.Session.SetString("coming_from_page", "you came from index"); HttpContext.Session.SetInt32("Comingfrompage", 1); }
            else if (jumpedfrompagename == "privacy") { HttpContext.Session.SetString("coming_from_page", "you came from privacy"); HttpContext.Session.SetInt32("Comingfrompage", 2); }
            else if (jumpedfrompagename == "about") { HttpContext.Session.SetString("coming_from_page", "you came from about"); HttpContext.Session.SetInt32("Comingfrompage", 3); }


        }
        public IActionResult Privacy()
        {
            ViewBag.Comingfrompage = HttpContext.Session.GetInt32("Comingfrompage");

            ViewBag.Nameofpreviouspage = HttpContext.Session.GetString("coming_from_page");
            ViewBag.Greetingmessage = HttpContext.Session.GetString("Greeting");
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Nameofpreviouspage = HttpContext.Session.GetString("coming_from_page");
            ViewBag.Comingfrompage = HttpContext.Session.GetInt32("Comingfrompage");
            ViewBag.Greetingmessage = HttpContext.Session.GetString("Greeting");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
