using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VGL.Data;
using VGL.Interfaces;
using VGL.Models;

namespace VGL.Controllers
{
    public class HomeController : Controller
    {
		IDataAccessLayer DAL = new VGL_DAL();

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Library()
		{
			return View(DAL.GetGames());
		}

        [HttpPost]
        public IActionResult Search(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                ViewBag.Search = $"";
                return View("Library", DAL.GetGames());
            }
            ViewBag.Search = $"Query: \"{key}\".";
            return View("Library", DAL.Search(key));
        }

        [HttpPost]
		public IActionResult Loan(string LoanOut, int? id)
		{
			if (!id.HasValue) return NotFound();

			DAL.Loan(id, LoanOut);
			return View("Library", DAL.GetGames());
		}

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VideoGame game)
        {
            if (ModelState.IsValid)
            {
                DAL.AddGame(game);
                return View("Library", DAL.GetGames());
            }
            return View();
        }

        [HttpPost]
		public IActionResult Delete(int? id)
		{
			if (!id.HasValue) return NotFound();

			DAL.RemoveGame(id);
			return View("Library", DAL.GetGames());
		}

		[HttpGet]
		public IActionResult Edit(int? id)
		{
			if (!id.HasValue) return NotFound();

			VideoGame found = DAL.GetGame(id);

			if (found == null) return NotFound();

			return View(found);
		}

        [HttpPost]
        public IActionResult Edit(VideoGame game)
        {
            if (ModelState.IsValid)
            {
                DAL.Edit(game);
                return View("Library", DAL.GetGames());
            }
            return View();
        }
	}
}