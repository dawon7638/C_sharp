using Microsoft.AspNetCore.Mvc;

namespace Portfolio_II.Controllers
{
    public class HomeController : Controller
    {
        // Requests
        // localhost:5000/
        [HttpGet("")]
        public IActionResult Home()
        {
            ViewBag.Header = "About Me";
            ViewBag.MyName = "Moose Phillips";
            ViewBag.Caption = "I like stuff!";

            return View("Home");
        }

        // localhost:5000/projects
        [HttpGet("projects")]
        public ViewResult Projects()
        {
            
            return View("Projects");
        }
        // localhost:5000/contact
        [HttpGet("contact")]

        public ViewResult Contact()
        {
            return View("Contact");
        }

        [HttpPost("contact")]
        public RedirectToActionResult afterRedirect()
        {
            return RedirectToAction("Home");
        }


    }
}