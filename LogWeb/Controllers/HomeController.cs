using LogWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LogWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyLogger _log;

        public HomeController(ILogger<HomeController> logger, MyLogger log)
        {
            _log = log;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _log.Write("Qualcuno ha visitato la pagina principale");

            return View();
        }

        public IActionResult Privacy()
        {
            _log.Write("Qualcuno ha visitato la pagina privacy");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}