using System;
using Microsoft.AspNetCore.Mvc;

namespace Time_Display.Controllers
{
    public class HomeController : Controller
    {
        
        // Requests
        // localhost:5000/
        [HttpGet("")]
        public IActionResult Home()
        {
            
            ViewBag.Header = "The current time and date:";
            
            
            return View("Home");
        }


    }
}