using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dojodachi.Models;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        /*
            [x] Your Dojodachi should start with 20 happiness, 20 fullness, 50 energy, and 3 meals.
            [x] After every button press, display a message showing how the Dojodachi reacted
            [x] Feeding your Dojodachi costs 1 meal and gains a random amount of fullness between 5 and 10 (you cannot feed your Dojodachi if you do not have meals)
            [x] Playing with your Dojodachi costs 5 energy and gains a random amount of happiness between 5 and 10
            [x] Every time you play with or feed your dojodachi there should be a 25% chance that it won't like it. Energy or meals will still decrease, but happiness and fullness won't change.
            [x] Working costs 5 energy and earns between 1 and 3 meals
            [x] Sleeping earns 15 energy and decreases fullness and happiness each by 5
            [x] If energy, fullness, and happiness are all raised to over 100, you win! a restart button should be displayed.
            [] If fullness or happiness ever drop to 0, you lose, and a restart button should be displayed.
        */
        [HttpGet("/")]
        public IActionResult IndexView()

        {   ///Sessions
            PetModel Rooster = new PetModel();
            /////////////////////////////FULLNESS\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            HttpContext.Session.SetInt32("Fullness", Rooster.Fullness);
            ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");

            /////////////////////////////HAPPINESS\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            HttpContext.Session.SetInt32("Happiness", Rooster.Happiness);
            ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");

            /////////////////////////////MEALS\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            HttpContext.Session.SetInt32("Meals", Rooster.Meals);
            ViewBag.Meals = HttpContext.Session.GetInt32("Meals");

            /////////////////////////////ENERGY\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            HttpContext.Session.SetInt32("Energy", Rooster.Energy);
            ViewBag.Energy = HttpContext.Session.GetInt32("Energy");

            return View("IndexView");
        }

        [HttpPost("/feed")]
        public IActionResult Feed()
        // [x] Feeding your Dojodachi costs 1 meal and gains a random amount of fullness between 5 and 10 (you cannot feed your Dojodachi if you do not have meals)
        {
            Console.WriteLine("Feed Button");
            int? MealCount = HttpContext.Session.GetInt32("Meals");
            if (MealCount > 0)
            {
                MealCount--;
                HttpContext.Session.SetInt32("Meals", (int)MealCount);
                ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
            }
            else
            {
                ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
            }

            Random rand = new Random();
            int? Full = HttpContext.Session.GetInt32("Fullness");
            if (ViewBag.Meals > 0)
            {
                Full += rand.Next(5, 10);
                HttpContext.Session.SetInt32("Fullness", (int)Full);
                string alert = new string("You fed Rooster! Fullness increase, but your Meals decrease");
                ViewBag.Alert = alert;
            }
            else
            {
                ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
                string alert = new string("The cupboards are bare please get more food!");
                ViewBag.Alert = alert;
            }

            ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
            ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
            return View("IndexView");
        }
        [HttpPost("/play")]
        public IActionResult Play()
        /*
        [x] Playing with your Dojodachi costs 5 energy and gains a random amount of happiness between 5 and 10
        [x] Every time you play with or feed your dojodachi there should be a 25% chance that it won't like it. Energy or meals will still decrease, but happiness and fullness won't change.
        */
        {
            Console.WriteLine("Play Button");
            int? funTimes = HttpContext.Session.GetInt32("Energy");
            if (funTimes >= 5)
            {
                funTimes -= 5;
                HttpContext.Session.SetInt32("Energy", (int)funTimes);
                ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
            }
            else
            {
                ViewBag.Energy = 0;
            }
            Random rand = new Random();
            int? Happy = HttpContext.Session.GetInt32("Happiness");

            if (ViewBag.Energy > 0)
            {
                Happy += rand.Next(5, 10);
                HttpContext.Session.SetInt32("Happiness", (int)Happy);
                ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
                string alert = new string("You played with Rooster his Happiness increased");
                ViewBag.Alert = alert;
            }
            else
            {
                ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
                string alert = new string("Rooster is all pooped out, he needs some beauty Sleep!");
                ViewBag.Alert = alert;
            }
            ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
            ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");


            return View("IndexView");
        }
        [HttpPost("/work")]
        public IActionResult Work()
        //[x] Working costs 5 energy and earns between 1 and 3 meals
        {
            Console.WriteLine("Work Button");
            int? WorkCount = HttpContext.Session.GetInt32("Energy");
            if (WorkCount >= 5)
            {
                WorkCount -= 5;
                HttpContext.Session.SetInt32("Energy", (int)WorkCount);
                ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
            }
            else
            {
                ViewBag.Energy = 0;
            }

            Random rand = new Random();
            int? MealNum = HttpContext.Session.GetInt32("Meals");

            if (ViewBag.Energy > 5)
            {
                MealNum  += rand.Next(1, 3);
                HttpContext.Session.SetInt32("Meals", (int)MealNum);
                ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
                string message = new string("You worked with Rooster! Unfortunately his Energy decreased, but you added food to your cupboards! Meals increased");
                ViewBag.message = message;
            }
            else
            {
                ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
                string message = new string("Rooster is too burned out to do some hard labor!");
                ViewBag.message = message;
            }

            ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
            ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");



            return View("IndexView");
        }

        [HttpPost("/sleep")]
        public IActionResult Sleep()
        //[x] Sleeping earns 15 energy and decreases fullness and happiness each by 5
        {
            Console.WriteLine("Sleep Button");
            int? sleep = HttpContext.Session.GetInt32("Energy");
            sleep = +15;
            HttpContext.Session.SetInt32("Energy", (int)sleep);
            ViewBag.Energy = HttpContext.Session.GetInt32("Energy");


            int? rested = HttpContext.Session.GetInt32("Happiness");
            rested = -5;
            HttpContext.Session.SetInt32("Happiness", (int)rested);
            ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");

            int? SleepFull = HttpContext.Session.GetInt32("Fullness");
            SleepFull = -5;
            HttpContext.Session.SetInt32("Fullness", (int)SleepFull);
            ViewBag.Fullness = HttpContext.Session.GetInt32("fullness");


            string alert = new string("Rooster got some beauty sleep his Energy increased, but his Happiness and Fullness decreased.  Please feed and play with Rooster!");
            ViewBag.Alert = alert;



            ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
            ViewBag.Meals = HttpContext.Session.GetInt32("Meals");


            return View("IndexView");
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
