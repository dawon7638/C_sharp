using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using view_models_fun.Models;

namespace view_models_fun.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        ///////////////////////////////////////Home View\\\\\\\\\\\\\\\\\\\\\\
        [HttpGet("")]
        public IActionResult HomeView()
        {
            HomeModel someRandomParagraph = new HomeModel()
            {
                Paragraph = "Well done Watson! You did great today!"
            };
            return View(someRandomParagraph);
        }

        ///////////////////////////////////////Numbers View\\\\\\\\\\\\\\\\\\\\\\
        [HttpGet("/numbers")]
        public IActionResult NumbersView()

        {
            Random rand = new Random();
            int[] Numbers = new int[10];
            for (int i = 0; i < Numbers.Length; i++)
            {
                Numbers[i] = rand.Next(0, 10);
            }
            return View("NumbersView", Numbers);
        }
        public IActionResult Privacy()
        {

            return View();
        }
        //////////////////////LIST OF USERS VIEW\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        [HttpGet("/users")]
        public IActionResult UsersView()
        {

            List<string> ListofUsers = new List<string>()
        {
            "Moose Phillips",
            "Sarah",
            "Jerry",
            "Rene Ricky",
            "Barborah"
        };
            return View("UsersView", ListofUsers);
        }
        ///////////////////////////////////////SINGLE USER VIEW\\\\\\\\\\\\\\\\\\\\\\
        [HttpGet("/user")]
        public IActionResult UserView()
        {
            UserModel UserName = new UserModel()
            {

                Name = "Moose Phillips"
            };

            return View(UserName);
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
