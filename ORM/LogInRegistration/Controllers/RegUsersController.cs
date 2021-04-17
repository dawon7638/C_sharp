using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LogInRegistration.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace LogInRegistration.Controllers
{
    public class RegUsersController : Controller
    {
        private LogInRegistrationContext db;
        public RegUsersController(LogInRegistrationContext context)
        {
            db = context;
        }

        ////////////////////////VIEWS\\\\\\\\\\\\\\\\\\\\\\\\\\
        [HttpGet("/")]///REGISTER VIEW\\\\
        public IActionResult Index()
        {
            return View("Register");
        }
        ///////////////////////////////////////////////////////

        ////////////////////////POSTS\\\\\\\\\\\\\\\\\\\\\\\\\\
        [HttpPost("/register")]///REGISTER POST\\\\

        public IActionResult Register(RegUser newUser)
        {
            if (ModelState.IsValid)
            {
                bool existingUser = db.RegUsers.Any(ru => ru.Email == newUser.Email);
                if (existingUser)
                {
                    ModelState.AddModelError("Email", "This is not your email!");
                }
            }
            if (ModelState.IsValid == false)
            {
                return View("Register");
            }

            PasswordHasher<RegUser> hasher = new PasswordHasher<RegUser>();
            newUser.Password = hasher.HashPassword(newUser, newUser.Password);

            db.RegUsers.Add(newUser);
            db.SaveChanges();

            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            return RedirectToAction("Login", "LogUsers", newUser);
        }
        ///////////////////////////////////////////////////////






    }
}