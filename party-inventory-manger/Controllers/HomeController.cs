using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInventoryManger.Models;

namespace PartyInventoryManger.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Platinum"] = "0";
            ViewData["Gold"] = "0";
            ViewData["Silver"] = "0";
            ViewData["Copper"] = "0";
            ViewData["Total"] = "0";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Concept";
            ViewData["Para1"] = "This program is meant to help you and your party keep track of your ineventory. It currently is designed for pathfinder 2E but may be expanded to other systems.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
