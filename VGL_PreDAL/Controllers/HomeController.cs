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
            new VideoGame("Pikmin", "GameCube", "Real- Time Strategy, Puzzle", "E", 2001, "pik1.jpg"),
            new VideoGame("Pikmin 2", "GameCube", "Real- Time Strategy, Puzzle", "E", 2004, "pik2.jpg"),
            new VideoGame("Pikmin 3", "Wii U", "Real- Time Strategy, Puzzle", "E", 2013, "pik3.png"),
            new VideoGame("Pikmin 4", "Nintendo Switch", "Real- Time Strategy, Puzzle", "E", 2023, "pik4.jpg"),
            new VideoGame("Pikmin Bloom", "Mobile", "Real- Time Strategy, Puzzle", "E", 2021, "pik5.png")
        };

        private static List<VideoGame> Library = new List<VideoGame>
        {
            new VideoGame("Pikmin", "GameCube", "Real- Time Strategy, Puzzle", "E", 2001, "pik1.jpg"),
            new VideoGame("Pikmin 2", "GameCube", "Real- Time Strategy, Puzzle", "E", 2004, "pik2.jpg"),
            new VideoGame("Pikmin 3", "Wii U", "Real- Time Strategy, Puzzle", "E", 2013, "pik3.png"),
            new VideoGame("Pikmin 4", "Nintendo Switch", "Real- Time Strategy, Puzzle", "E", 2023, "pik4.jpg"),
            new VideoGame("Pikmin 4", "Nintendo Switch", "Real- Time Strategy, Puzzle", "E", 2021, "pik5.png")
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

        [HttpGet]
        public IActionResult Loan()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Loan(string title, string platform, string genre, string rating, string year, string loanedTo, string loanDate)
        {
            if (title != null)
            {
                //LoanedGame(VideoGames, title, loanedTo, loanDate);
                VideoGames.Add(new VideoGame(title, platform, genre, rating, int.Parse(year), "nia.jpg", loanedTo, loanDate));
                TempData["success"] = "Game Loaned";
                return RedirectToAction("Collection");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Return()
        {
            return View();
        }

        public IActionResult Collection()
        {
            ViewData["Title"] = "Collection";
            return View(VideoGames);
        }

        [HttpPost]
        public IActionResult Return(string title)
        {
            if (title != null)
            {
                ReturnGame(VideoGames, title);
                TempData["success"] = "Game Returned";
                return RedirectToAction("Collection");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void LoanedGame(List<VideoGame> games, string title, string name, string date)
        {
            foreach (VideoGame g in games)
            {
                if (g.Title == title)
                {
                    g.LoanedTo = name;
                    g.LoanDate = date;
                }
            }
        }

        public void ReturnGame(List<VideoGame> games, string title)
        {
            foreach (VideoGame g in games)
            {
                if (g.Title == title)
                {
                    g.LoanedTo = null;
                    g.LoanDate = null;
                    VideoGames.Remove(g);
                    break;
                }
            }
        }
    }
}