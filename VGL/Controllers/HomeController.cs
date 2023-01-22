using Microsoft.AspNetCore.Http.Extensions;
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
            new VideoGame("Pikmin", "GameCube", "Real- Time Strategy, Puzzle", "E", 2001, "pik1.jpg", "John Doe", new DateOnly(2023, 1, 30)),
            new VideoGame("Pikmin 2", "GameCube", "Real- Time Strategy, Puzzle", "E", 2004, "pik2.jpg"),
            new VideoGame("Pikmin 3", "Wii U", "Real- Time Strategy, Puzzle", "E", 2013, "pik3.png")
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

        public void Submit(int ID, string LoanedTo)
        {
            VideoGame game = VideoGames.Find(g => g.Id == ID);
            //game.LoanedTo = LoanedTo;
            //game.LoanDate = (DateOnly.FromDateTime(DateTime.Now));

            Console.WriteLine(game.Title);

            Collection();
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