using Microsoft.AspNetCore.Mvc;

namespace RuoliIdentity.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
