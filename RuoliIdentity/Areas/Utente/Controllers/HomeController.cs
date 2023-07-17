using Microsoft.AspNetCore.Mvc;

namespace RuoliIdentity.Areas.Utente.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
