using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dojo_Survey.Controllers
{
    public class HomeController : Controller
    {
        // Requests
        // localhost:5000/
        [HttpGet("")]
        public IActionResult Form()
        {

            return View("Form");
        }

        // Requests
        // localhost:5000/result
        [HttpPost("result")]

        public IActionResult Result(string name, string location, string language, string comment)
        {   
            // Form information 
            ViewBag.Header = ("Submitted Info");
            ViewBag.Name = (name);
            ViewBag.Location = (location);
            ViewBag.Language = (language);
            ViewBag.Comment = (comment);
            return View("Result");
        }
    }
}