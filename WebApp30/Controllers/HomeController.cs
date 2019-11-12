using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebApp30.Models;

namespace WebApp30.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ISomeService _someService;
		private IConfiguration _configuration;

		public HomeController(ILogger<HomeController> logger, ISomeService someService, IConfiguration configuration)
		{
			_logger = logger;
			_someService = someService;
			_configuration = configuration;
		}

		public IActionResult Index()
		{
			ViewBag.ServicePing = _someService.Ping();
			ViewBag.Setting1 = _configuration.GetValue<string>("Setting1");
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
