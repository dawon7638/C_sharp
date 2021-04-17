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
    public class LogUsersController : Controller
    {
        private int? uid
        {
            get
            {
                return HttpContext.Session.GetInt32("LogId");
            }
        }
        private bool isLoggedIn
        {
            get
            {
                return uid != null;
            }
        }
        private LogInRegistrationContext db;
        public LogUsersController(LogInRegistrationContext context)
        {
            db = context;
        }
        ////////////////////////VIEWS\\\\\\\\\\\\\\\\\\\\\\\\\\
        [HttpGet("/login")]///LOGIN VIEW\\\\
        public IActionResult Credentials()
        {
            return View("Login");
        }

        [HttpGet("/success")]///SUCCESS VIEW\\\\
        public IActionResult Success(LogUser user)
        {
            if (!isLoggedIn)
            {
                Console.WriteLine("I'm from success method");
                return RedirectToAction("Login");
            }
            return View("Success", user);
        }
        ///////////////////////////////////////////////////////

        ////////////////////////POSTS\\\\\\\\\\\\\\\\\\\\\\\\\\
        [HttpPost("/login")]///LOGIN POST\\\\
        public IActionResult Login(LogUser user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = db.RegUsers.FirstOrDefault(ru => ru.Email == user.LoginEmail);
                if (existingUser == null)
                {
                    ModelState.AddModelError("LoginEmail", "This is not you!");
                }
                PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>();

                var result = hasher.VerifyHashedPassword(user, existingUser.Password, user.LoginPassword);

                if (result == 0)
                {
                    ModelState.AddModelError("LoginPassword", "This is not you!"); return View("Login");
                }

            }
            HttpContext.Session.SetInt32("LogId", user.LogId);
            return RedirectToAction("Success", user);


        }
        [HttpPost("/logout")]///LOGOUT POST\\\\
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        ///////////////////////////////////////////////////////
    }
}