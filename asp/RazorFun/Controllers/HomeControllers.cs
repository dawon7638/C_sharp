using Microsoft.AspNetCore.Mvc;
namespace RazorFun
{
    public class HomeController : Controller
    {
        // Requests
        // localhost:5000/
        [HttpGet("")]
        public ViewResult Index()
        {
            return View("Index");
        }



    }
}