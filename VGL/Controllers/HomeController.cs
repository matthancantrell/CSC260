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
            new VideoGame("Pikmin", "GameCube", "Real- Time Strategy, Puzzle", "E", 2001, ""),
            new VideoGame("Pikmin 2", "GameCube", "Real- Time Strategy, Puzzle", "E", 2004, ""),
            new VideoGame("Pikmin 3", "Wii U", "Real- Time Strategy, Puzzle", "E", 2013, "")
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