using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RuoliIdentity.Areas.Utente.Controllers
{
    [Area("Utente")]
    [Authorize(Roles ="Utente")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
