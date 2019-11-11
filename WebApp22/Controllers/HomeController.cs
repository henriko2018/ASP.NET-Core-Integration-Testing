using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp22.Models;

namespace WebApp22.Controllers
{
	public class HomeController : Controller
	{
		private readonly ISomeService _someService;

		public HomeController(ISomeService someService)
		{
			_someService = someService;
		}

		public IActionResult Index()
		{
			ViewBag.ServicePing = _someService.Ping();
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
