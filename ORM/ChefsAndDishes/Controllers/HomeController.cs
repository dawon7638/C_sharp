using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChefsAndDishes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ChefsAndDishes.Controllers
{
    public class HomeController : Controller
    {
        private ChefsAndDishesContext db;

        public HomeController(ChefsAndDishesContext context)
        {
            db = context;
        }
        ////////////////////////VIEWS\\\\\\\\\\\\\\\\\\\\\\\\\\
        [HttpGet("/")]//ALL CHEFS VIEW\\
        public IActionResult AllChefs()
        {
            List<Chef> allChefs = db.Chefs.Include(chef => chef.Dishes).ToList();
            return View("AllChefs", allChefs);
        }
        ///////////////////////////////////////////////////////
        [HttpGet("/dishes")]//ALL DISHES VIEW\\
        public IActionResult AllDishes()
        {
            List<Dish> allDishes = db.Dishes.Include(dish => dish.Cooker).ToList();
            return View("AllDishes", allDishes);
        }
        ///////////////////////////////////////////////////////
        [HttpGet("/new")]//ADD CHEF VIEW\\
        public IActionResult NewChef()
        {
            return View("NewChef");
        }
        ///////////////////////////////////////////////////////
        [HttpGet("/dishes/new")]//ADD A DISH VIEW\\
        public IActionResult NewDish()
        {
            List<Chef> allChefs = db.Chefs.ToList();
            ViewBag.AddingChefs = allChefs;
            return View("NewDish");
        }
        ///////////////////////////////////////////////////////

        ////////////////////////POSTS\\\\\\\\\\\\\\\\\\\\\\\\\\
        [HttpPost("/CreateChef")]//ADD A CHEF FORM\\
        public IActionResult CreateChef(Chef newChef)
        {
            Console.WriteLine("New chef created!");
            if (ModelState.IsValid == false)
            {
                return View("NewChef");
            }

            int today = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int DOB = int.Parse(newChef.DOB.ToString("yyyyMMdd"));
            int age = (today - DOB) / 10000;

            if (DOB == today)
            {
                ModelState.AddModelError("DOB", "Date must not be today!");
                return View("NewChef");
            }

            if (age < 18)
            {
                ModelState.AddModelError("DOB", "Chef must be at least 18 years old!");
                return View("NewChef");
            }

            db.Chefs.Add(newChef);
            db.SaveChanges();
            return RedirectToAction("AllChefs");
        }
        ///////////////////////////////////////////////////////
        [HttpPost("/CreateDish")]//ADD A DISH FORM\\
        public IActionResult CreateDish(Dish newDish)
        {
            Console.WriteLine("New dish created!");
            if (ModelState.IsValid == false)
            {
                List<Chef> allChefs = db.Chefs.ToList();
                ViewBag.AddingChefs = allChefs;
                return View("NewDish");

            }
            db.Dishes.Add(newDish);
            db.SaveChanges();
            return RedirectToAction("AllDishes");
        }
        ///////////////////////////////////////////////////////




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
