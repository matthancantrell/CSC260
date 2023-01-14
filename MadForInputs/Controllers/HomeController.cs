using MadForInputs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MadForInputs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Input()
        {
            ViewData["Title"] = "Input Form";
            return View();
        }

        public IActionResult Output(string Name, string TownName,
            string HowIsItBeingDone, string WhatsWrong,
            string WeaponThatIsNotAWeapon)
        {
            ViewBag.N = Name;
            ViewBag.TN = TownName;
            ViewBag.HIIBD = HowIsItBeingDone;
            ViewBag.WW = WhatsWrong;
            ViewBag.WTINAW = WeaponThatIsNotAWeapon;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}