using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Validation.Models;

namespace Validation.Controllers
{
	public class HomeController : Controller
	{
		public static List<Profile> profiles = new List<Profile>();

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Profile p)
		{
			if (ModelState.IsValid)
			{
				profiles.Add(p);
				TempData["success"] = "Profile added";
				return RedirectToAction("ProfileView", "Home");
			}
			return View();
		}

		public IActionResult ProfileView()
		{
			return View(profiles);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
