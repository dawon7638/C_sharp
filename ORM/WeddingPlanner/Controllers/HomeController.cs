using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {

        private int? uid
        {
            get
            {
                return HttpContext.Session.GetInt32("UserId");
            }
        }
        private bool isLoggedIn
        {
            get
            {
                return uid != null;
            }
        }
        private WeddingPlannerContext db;
        public HomeController(WeddingPlannerContext context)
        {
            db = context;
        }


        [HttpGet("/")]
        public IActionResult Index()
        {
        
            return View("Index");
        }


        [HttpPost("/register")]
        public IActionResult Register(User newUser)
        {
            if (ModelState.IsValid)
            {
                bool existingUser = db.Users
                .Any(user => user.Email == newUser.Email);
                if (existingUser)
                {
                    ModelState.AddModelError("Email", "Is already registered.");
                }
            }
            if (ModelState.IsValid == false)
            {
                return View("Index");
            }
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            newUser.Password = hasher.HashPassword(newUser, newUser.Password);
            db.Users.Add(newUser);
            db.SaveChanges();

            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            HttpContext.Session.SetString("FullName", newUser.FullName());
            return RedirectToAction("Dashboard", "Weddings");
        }

        [HttpPost("/log")]
        public IActionResult Login(LogUser logUser)
        {  /* 
            For security, don't reveal what was invalid.
            You can make your error messages more specific to help with testing
            but on a live site it should be ambiguous.
            */
            string genericErrMsg = "Invalid Email or Password";

            if (ModelState.IsValid == false)
            {
                // So error messages will be displayed.
                return View("Index");
            }

            User dbUser = db.Users.FirstOrDefault(user => user.Email == logUser.LogEmail);

            if (dbUser == null)
            {
                ModelState.AddModelError("LogEmail", genericErrMsg);
                // So error messages will be displayed.
                return View("Index");
            }

            // User found b/c the above didn't return.
            PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>();
            PasswordVerificationResult pwCompareResult = hasher.VerifyHashedPassword(logUser, dbUser.Password, logUser.LogPassword);

            if (pwCompareResult == 0)
            {
                ModelState.AddModelError("LogEmail", genericErrMsg);
                return View("Index");
            }

            // Password matched.
            HttpContext.Session.SetInt32("UserId", dbUser.UserId);
            HttpContext.Session.SetString("FullName", dbUser.FullName());
            return RedirectToAction("Dashboard", "Weddings");
        }

        [HttpPost("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        /////////////////END\\\\\\\\\\\\\\\\\\\\\\

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
