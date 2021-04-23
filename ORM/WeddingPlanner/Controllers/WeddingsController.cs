using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class WeddingsController : Controller
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
        public WeddingsController(WeddingPlannerContext context)
        {
            db = context;
        }


        [HttpGet("/Dashboard")]
        public IActionResult Dashboard()
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Wedding> weddings = db.Weddings
            .Include(w => w.RSVPs)
            //     .ThenInclude(u => u.User)
            // .Include(w => w.CreatedBy)
            .ToList();
            return View("Dashboard", weddings);
        }

        [HttpGet("/create/wedding")]
        public IActionResult New()
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("New");
        }

        [HttpGet("/WeddingDetails/{WeddingId}")]
        public IActionResult Details(int WeddingId)
        {
            Wedding currentWedding = db.Weddings
            .Include(cw => cw.RSVPs)
            .ThenInclude(rsvp => rsvp.User)
            .FirstOrDefault(cw => cw.WeddingId == WeddingId);

            if (currentWedding == null)
            {
                return RedirectToAction("Dashboard");
            }
            return View("Details", currentWedding);
        }


        [HttpPost("/new/wedding")]
        public IActionResult Create(Wedding newWedding)
        {
            //Clears default date error.
            //So I can add my own error message 

            if (ModelState.ContainsKey("Date") == true)
            {
                ModelState["Date"].Errors.Clear();
            }
            if (newWedding.Date <= DateTime.Now)
            {
                ModelState.AddModelError("Date", "must be in the future.");
            }
            if (!ModelState.IsValid)
            {
                return View("New");
            }

            newWedding.UserId = (int)uid;
            db.Weddings.Add(newWedding);
            db.SaveChanges();

            return RedirectToAction("Details", new { WeddingId = newWedding.WeddingId });
        }

        [HttpPost("/weddings/{WeddingId}/delete")]
        public IActionResult Delete(int weddingId)
        {
            Wedding wedding = db.Weddings.FirstOrDefault(w => w.WeddingId == weddingId);

            if (wedding != null)
            {
                db.Weddings.Remove(wedding);
                db.SaveChanges();
            }
            return RedirectToAction("Dashboard");
        }

        [HttpPost("/weddings/{WeddingId}")]
        public IActionResult RSVP(int weddingId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            Guest existingRSVP = db.Guests
                .FirstOrDefault(rsvp => rsvp.UserId == uid && rsvp.WeddingId == weddingId);

            if (existingRSVP == null)
            {
                Guest rsvp = new Guest()
                {
                    WeddingId = weddingId,
                    UserId = (int)uid
                };

                db.Guests.Add(rsvp);
            }
            else
            {
                db.Guests.Remove(existingRSVP);
            }

            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }






















    }
}