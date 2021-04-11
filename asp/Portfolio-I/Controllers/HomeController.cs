using Microsoft.AspNetCore.Mvc;
namespace Portfolio_I.Controllers
{
    public class HomeController : Controller
    {
        // Requests
        // localhost:5000/
        [HttpGet("")]
        public string Index()
        {
            return "This is my Index";
        }

        // localhost:5000/projects
        [HttpGet("projects")]
        public string Hello()
        {
            return "These are my projects";
        }
        // localhost:5000/contact
        [HttpGet("contact")]

        public string HelloUser(string username, string location)
        {
            return "This is my Contact!";



        }

    }
}