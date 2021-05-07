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
        public IActionResult ProductsIndex()
        {
            List<Product> allProduct = new List<Product>();
            return View("Products", allProduct);
        }

        [HttpGet("/categories")]
        public IActionResult CategoriesIndex()
        {
            List<Category> allCategories = new List<Category>();
            return View("Categories", allCategories);
        }

        [HttpPost("/newProduct")]
        public IActionResult CreateProduct(Product newProduct)
        {
            db.Products.Add(newProduct);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost("/newCategory")]

        public IActionResult CreateCategory(Category newCategory)
        {
            db.Categories.Add(newCategory);
            db.SaveChanges();

            return RedirectToAction("Categories");
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
