using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BankAccts.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BankAccts.Controllers
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
        private BankAcctsContext db;
        public HomeController(BankAcctsContext context)
        {
            db = context;
        }
        ////////////////////////GETS\\\\\\\\\\\\\\\\\\\\\\\\\\

        [HttpGet("/")]///REGISTER VIEW\\\\
        public IActionResult Reg()
        {
            return View();
        }
        ///////////////////////////////////////////////////////

        [HttpGet("/login")]///LOGIN VIEW\\\\
        public IActionResult Login()
        {
            return View("Log");
        }
        ///////////////////////////////////////////////////////

        [HttpGet("/account/{UserId}")]///ACCT DISP. VIEW\\\\
        public IActionResult AccountDisplay(int UserId)
        {

            if (uid != UserId)
            {
                Console.WriteLine("I'm from AccountDisplay method");
                return Redirect($"/account/{uid}");
            }


            ViewBag.Balance = db.Transactions.Sum(b=>b.Amount);
            User singleUser = db.Users.Include(u => u.Transactions).SingleOrDefault(u => u.UserId == UserId);
                ViewBag.singleUser = singleUser;

            User CurrentUser = db.Users.Include(user => user.Transactions).Where(user => user.UserId == UserId).SingleOrDefault();

            List<Transaction> allTransactions = db.Transactions.Include(tran => tran.AccountHolder).ToList();

            ViewBag.AccountUser = allTransactions;
            return View("Display", CurrentUser);
        }
        ///////////////////////////////////////////////////////

        ////////////////////////POSTS\\\\\\\\\\\\\\\\\\\\\\\\\\

        [HttpPost("/createUser")]///REGISTER USER FORM\\\\
        public IActionResult Create(User newUser)
        {
            if (ModelState.IsValid)
            {
                bool existingUser = db.Users.Any(user => user.Email == newUser.Email);
                if (existingUser)
                {
                    ModelState.AddModelError("Email", "Something went wrong when you entered your email address.");
                }
            }
            if (ModelState.IsValid == false)
            {
                return View("Reg");
            }
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            newUser.Password = hasher.HashPassword(newUser, newUser.Password);

            db.Users.Add(newUser);
            db.SaveChanges();
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            return RedirectToAction("AccountDisplay", newUser);
        }
        ///////////////////////////////////////////////////////

        [HttpPost("/loginUser")]///LOGIN USER FORM\\\\
        public IActionResult LoginUser(LogUser logUser)
        {
            if (ModelState.IsValid)
            {
                User existingUser = db.Users.FirstOrDefault(user => user.Email == logUser.LoginEmail);
                if (existingUser == null)
                {
                    ModelState.AddModelError("LoginEmail", "Incorrect login information");
                    return RedirectToAction("Log");
                }
                PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>();
                var result = hasher.VerifyHashedPassword(logUser, existingUser.Password, logUser.LoginPassword);

                if (result == 0)
                {
                    ModelState.AddModelError("LoginPassword", "Incorrect login information");
                    return RedirectToAction("Log");
                }
                HttpContext.Session.SetInt32("UserId", existingUser.UserId);
                return RedirectToAction("AccountDisplay", new { UserId = existingUser.UserId });
            }
            return View("Log");
        }
        ///////////////////////////////////////////////////////

        [HttpPost("/transaction")]///TRANSACTIONS FORM\\\\
        public IActionResult Transaction(Transaction newTransaction)
        {
            // var accountTotal = HttpContext.Session.GetInt32()
            // if (newTransaction > accountTotal)
            // {

            // }
            db.Transactions.Add(newTransaction);
            db.SaveChanges();
            HttpContext.Session.SetInt32("TransactionId", newTransaction.TransactionId);
            int? UserId = HttpContext.Session.GetInt32("UserId");
            Console.WriteLine("I'm UserId" + UserId);
            return Redirect($"/account/{UserId}");
        }
        ///////////////////////////////////////////////////////

        [HttpPost("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Reg");
        }
        ///////////////////////////////////////////////////////
        //////////////////////END//////////////////////////////







        //dotnet ef migrations add Initial
        //dotnet ef database update
















        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
