using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dojo_Survey_With_Models.Models;

namespace Dojo_Survey_With_Models.Controllers
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

        // Requests
        // localhost:5000/result
        [HttpPost("/result")]

        public IActionResult Result(UserModel user)//UserModel is being passed as a parameter from the UserModel class. Also will need a variable(user)
        {
            // Form information 
            ViewBag.Header = ("Submitted Info");
            return View("ResultView", user);// Will need to return the view that needs to rendered("ResultView) and the variable(user).
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
