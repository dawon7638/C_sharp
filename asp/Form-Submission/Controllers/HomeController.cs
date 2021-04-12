using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Form_Submission.Models;

namespace Form_Submission.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /*
            [x] If there are errors, render the form page and display errors
            [x] If there are no errors, redirect to a success page
        */

        [HttpGet("/")]
        public IActionResult HomeView()
        {
            return View("HomeView");
        }

        [HttpPost("Create")]

        public IActionResult Create(UserModel newUser)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine();
                return RedirectToAction("SuccessView", newUser);
            }
            Console.WriteLine("Oops something went wrong");
            return View("HomeView");
        }

        [HttpGet("/success")]
        public IActionResult SuccessView()
        {
            return View("SuccessView");
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
