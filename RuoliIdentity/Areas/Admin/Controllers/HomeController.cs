using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RuoliIdentity.Areas.Admin.Controllers
{
    //Questo controller spiega al sistema che sta nell'area Admin
    // e che solo l'utente che ha ruolo 'Admin' può accedere
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
