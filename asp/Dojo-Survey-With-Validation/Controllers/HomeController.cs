using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dojo_Survey_With_Validation.Models;

namespace Dojo_Survey_With_Validation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // Requests
        // localhost:5000/
        [HttpGet("/")]
        public IActionResult FormView()
        {
            return View("FormView");
        }

        [HttpPost("Create")]
        public IActionResult Create(UserModel newUser)
        /*
            [x] If the submission is invalid, render errors
            [x]If the submission is successful, render the result page
        */
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine();
                return RedirectToAction("ResultView", newUser);
            }
            Console.WriteLine("Oops something went wrong");
            return View("FormView");
        }

        // Requests
        // localhost:5000/result 
        [HttpGet("/result")]
        public IActionResult ResultView(UserModel newUser)//UserModel is being passed as a parameter from the UserModel class. Also will need a variable(user)
        {
            // Form information 
            ViewBag.Header = ("Submitted Info");
            return View("ResultView", newUser);// Will need to return the view that needs to rendered("ResultView) and the variable(user).
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
