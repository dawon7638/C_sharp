using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Random_Passcode_Generator.Models;
using Microsoft.AspNetCore.Http;

namespace Random_Passcode_Generator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /*
         *Inside controller methods*

        To store a string in session we use ".SetString"
        The first string passed is the key and the second is the value we want to retrieve later
        HttpContext.Session.SetString("UserName", "Samantha");

        To retrieve a string from session we use ".GetString"
        string LocalVariable = HttpContext.Session.GetString("UserName");
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        To store an int in session we use ".SetInt32"
        HttpContext.Session.SetInt32("UserAge", 28);
        
        To retrieve an int from session we use ".GetInt32"
        int? IntVariable = HttpContext.Session.GetInt32("UserAge");
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        To clear session
        HttpContext.Session.Clear();
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        In your Controller
        Counting session
        ViewBag.Count = HttpContext.Session.GetInt32("count");


        */

        [HttpGet("/")]
        public IActionResult HomeView()
        {
            //Checking to see if there is a key in session.
            // First time the page has been loaded no information is stored in session.
            if (HttpContext.Session.GetInt32("sessionCheck") == null)
            {
            //Set if no session is found set session to one.
                HttpContext.Session.SetInt32("sessionCheck", 1);
            }
            else
            {
             //In current session increase current session count by one.
                int currnetCount = HttpContext.Session.GetInt32("sessionCheck").GetValueOrDefault();
                HttpContext.Session.SetInt32("sessionCheck", currnetCount + 1);
            }
            ViewBag.Count = HttpContext.Session.GetInt32("sessionCheck");
            Random rand = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var newCharString = new char[14];
            for (int i = 0; i < newCharString.Length; i++)
            {
                newCharString[i] = chars[rand.Next(0, 36)];
            }
            string newString = new String(newCharString);
            ViewBag.password = newString;
            return View("HomeView");
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
