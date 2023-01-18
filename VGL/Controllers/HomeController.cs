using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VGL.Models;

namespace VGL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private static List<VideoGame> VideoGames = new List<VideoGame>
        {
            new VideoGame("Pikmin", "SNES", "Adventure", "E", 6969, ""),
            /*new VideoGame(),
            new VideoGame(),
            new VideoGame(),
            new VideoGame() */
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Home";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Collection()
        {
            ViewData["Title"] = "Collection";
            return View(VideoGames);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}