using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            /////////////////////////////////////LEAGUES LVL1\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            ViewBag.WomenLeagues = _context.Leagues.Where(w => w.Name.Contains("Women")).ToList();
            ViewBag.HockeyLeagues = _context.Leagues.Where(h => h.Sport.Contains("Hockey")).ToList();
            ViewBag.OtherLeagues = _context.Leagues.Where(o => o.Sport != "Football").ToList();
            ViewBag.ConferenceLeagues = _context.Leagues.Where(c => c.Name.Contains("Conference")).ToList();
            ViewBag.AtlanticLeagues = _context.Leagues.Where(a => a.Name.Contains("Atlantic")).ToList();

            //////////////////////////////////////TEAMS LVL1\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            ViewBag.DallasTeams = _context.Teams.Where(d => d.Location.Contains("Dallas")).ToList();
            ViewBag.RaptorTeams = _context.Teams.Where(r => r.TeamName.Contains("Raptors")).ToList();
            ViewBag.CityTeams = _context.Teams.Where(c => c.Location.Contains("City")).ToList();
            ViewBag.StartsWithTTeams = _context.Teams.Where(swt => swt.TeamName.StartsWith("T")).ToList();
            ViewBag.LocationAToZTeams = _context.Teams.OrderBy(latz => latz.Location).ToList();
            ViewBag.NameZToATeams = _context.Teams.OrderByDescending(nzta => nzta.TeamName).ToList();

            /////////////////////////////////////PLAYERS LVL1\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            ViewBag.LastNameCooperPlayers = _context.Players.Where(lnc => lnc.LastName.Contains("Cooper")).ToList();
            ViewBag.FirstNameJoshuaPlayers = _context.Players.Where(fnj => fnj.FirstName.Contains("Joshua")).ToList();
            ViewBag.LastNameCooperNotFirstNameJoshuaPlayers = _context.Players.Where(lncnfnj => lncnfnj.LastName == "Cooper").Where(lncnfnj => lncnfnj.FirstName != "Joshua").ToList();
            ViewBag.FirstNameAlexanderOrFirstNameWyattPlayers = _context.Players.Where(fnaofnw => fnaofnw.FirstName == "Alexander" || fnaofnw.FirstName == "Wyatt").ToList();
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            //////////////////////////////////////TEAMS LVL2\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            ViewBag.AllTeamsInAtlanticConference = _context.Teams.Include(atiac => atiac.CurrLeague).Where(atiac => atiac.CurrLeague.Name == ("Atlantic Soccer Conference")).ToList();

            /////////////////////////////////////PLAYERS LVL2\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            ViewBag.BostonPlayers = _context.Players.Include(bp => bp.CurrentTeam).Where(bp => bp.CurrentTeam.TeamName == "Penguins" && bp.CurrentTeam.Location =="Boston").ToList();


            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}