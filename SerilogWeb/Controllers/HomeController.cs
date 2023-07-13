using Microsoft.AspNetCore.Mvc;
using SerilogWeb.Models;
using System.Diagnostics;

namespace SerilogWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogTrace("Trace pagina principale.");       // sarebbe il Verbose..
            _logger.LogDebug("Debug pagina principale.");
            _logger.LogInformation("Information pagina principale");
            _logger.LogWarning("Warning pagina principale.");
            _logger.LogError("Error pagina principale.");
            _logger.LogCritical("Critical pagina principale."); //sarebbe il Fatal

            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Visita alla pagina privacy");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}