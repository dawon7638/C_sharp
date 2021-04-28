using System;
using System.Collections.Generic;
using System.Linq;
using ActivityCtr.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ActivityCtr.Controllers
{
    public class EventsController : Controller
    {
        private ActivityCtrContext db;
        public EventsController(ActivityCtrContext context)
        {
            db = context;
        }


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
        [HttpGet("/home")]
        public IActionResult Home()
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Event> expiredEvents = db.Events
            .Where(w => w.Date < DateTime.Now)
            .ToList();

            db.RemoveRange(expiredEvents);
            db.SaveChanges();


            List<Event> events = db.Events
            .Include(e => e.People)
            .Include(e => e.CreatedBy)
            .ToList();
            return View("Home", events);


        }

        [HttpGet("/new")]

        public IActionResult New(Event newEvent)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("New",newEvent);
        }

        [HttpGet("/activity/{EventId}")]
        public IActionResult Details(int EventId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            Event currentEvent = db.Events
            .Include(ce => ce.CreatedBy)
            .Include(ce => ce.People)
                .ThenInclude(ce => ce.User)
            .FirstOrDefault(ce => ce.EventId == EventId);

            if (currentEvent == null)
            {
                return RedirectToAction("Home");
            }
            return View("Details", currentEvent);
        }



        [HttpPost("/create")]

        public IActionResult Create(Event newEvent)
        {
            //Clears default date error.
            //So I can add my own error message 

            if (ModelState.ContainsKey("Date") == true)
            {
                ModelState["Date"].Errors.Clear();
            }
            if (newEvent.Date <= DateTime.Now)
            {
                ModelState.AddModelError("Date", "must be in the future.");
            }
            if (!ModelState.IsValid)
            {
                return View("New");
            }
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }


            newEvent.UserId = (int)uid;
            db.Events.Add(newEvent);
            db.SaveChanges();

            // return RedirectToAction("Details", new { EventId = newEvent.EventId });
            //will need to change to details page.
            return RedirectToAction("Home");
        }

        [HttpPost("/event/{EventId}")]
        public IActionResult Join(int eventId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            Participant existingParticipant = db.Participants
                .FirstOrDefault(ep => ep.UserId == uid && ep.EventId == eventId);

            if (existingParticipant == null)
            {
                Participant ep = new Participant()
                {
                    EventId = eventId,
                    UserId = (int)uid
                };

                db.Participants.Add(ep);
            }
            else
            {
                db.Participants.Remove(existingParticipant);
            }

            db.SaveChanges();
            return RedirectToAction("Home");
        }

        [HttpPost("/events/{EventId}/delete")]
        public IActionResult Delete(int eventId)
        {
            Event currentEvent = db.Events.FirstOrDefault(ce => ce.EventId == eventId);

            if (currentEvent != null)
            {
                db.Events.Remove(currentEvent);
                db.SaveChanges();
            }
            return RedirectToAction("Home");
        }





    }
}