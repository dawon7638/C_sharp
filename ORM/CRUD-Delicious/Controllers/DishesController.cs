using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRUD_Delicious.Models;


namespace CRUD_Delicious.Controllers
{
    public class DishesController : Controller
    {
        private CRUD_DeliciousContext db;

        public DishesController(CRUD_DeliciousContext context)
        {
            db = context;
        }
        ////////////////////////VIEWS\\\\\\\\\\\\\\\\\\\\\\\\\\
        [HttpGet("/all")]
        public IActionResult AllDishesView()
        {
            List<DishModel> allDishes = db.Dishes.ToList();
            return View("AllDishesView", allDishes);
        }
        [HttpGet("/new")]

        public IActionResult MethodName()
        {
            return View("CreateDishView");
        }

        [HttpGet("/dishes/{dishid}")]

        // Params from the URL get turned into method params.
        public IActionResult Readview(int dishId)
        {
            DishModel dish = db.Dishes.FirstOrDefault(d => d.DishId == dishId);

            if (dish == null)
            {
                return RedirectToAction("AllDishesView");
            }
            return View("ReadView", dish);
        }

        [HttpGet("/edit/{dishId}")]


        public IActionResult Edit(int dishId)
        {
            DishModel dish = db.Dishes.FirstOrDefault(d => d.DishId == dishId);
            Console.WriteLine("What's in " + dish);

            if (dish == null)
            {
                return RedirectToAction("AllDishesView");
            }
            return View("EditOneView", dish);
        }
        ///////////////////////////////////////////////////////



        ////////////////////////POSTS\\\\\\\\\\\\\\\\\\\\\\\\\\
        [HttpPost("dishes/create")]
        public IActionResult Create(DishModel newDish)
        {
            Console.WriteLine("I'm creating!");
            if (ModelState.IsValid == false)
            {
                return View("CreateDishView");

            }
            // Validations are met add newDish to database
            db.Dishes.Add(newDish);
            db.SaveChanges();
            return RedirectToAction("AllDishesView");
        }

        [HttpPost("/dishes/{dishId}/delete")]
        public IActionResult Delete(int dishId)
        {
            DishModel dish = db.Dishes.FirstOrDefault(d => d.DishId == dishId);

            if (dish != null)
            {
                db.Dishes.Remove(dish);
                db.SaveChanges();
            }
            return RedirectToAction("AllDishesView");
        }

        [HttpPost("/dishes/{dishId}")]

        public IActionResult Update(DishModel editedDish, int dishId)
        {
            if (ModelState.IsValid == false)
            {
                editedDish.DishId = dishId;
                return View("EditOneView", editedDish);
            }
            DishModel dish = db.Dishes.FirstOrDefault(d => d.DishId == dishId);

            dish.Chef = editedDish.Chef;
            dish.Tastiness = editedDish.Tastiness;
            dish.Description = editedDish.Description;
            dish.Name = editedDish.Name;
            dish.Calories = editedDish.Calories;

            db.Dishes.Update(dish);
            db.SaveChanges();
            return RedirectToAction("ReadView", new {dishId = dishId});
        }
        ///////////////////////////////////////////////////////









    }
}