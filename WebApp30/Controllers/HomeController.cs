using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp30.Models;

namespace WebApp30.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ISomeService _someService;

		public HomeController(ILogger<HomeController> logger, ISomeService someService)
		{
			_logger = logger;
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
