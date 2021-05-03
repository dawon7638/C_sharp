using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prodCat.Models;

namespace prodCat.Controllers
{
    public class HomeController : Controller
    {
        private prodCatContext db;
        public HomeController(prodCatContext context)
        {
            db = context;
        }

        [HttpGet("/products")]
        public IActionResult Index()
        {
            return View("Products");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
