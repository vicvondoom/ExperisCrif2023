using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelloIdentityWeb.Controllers
{
    // Blocco tutte le action di questo controller
    [Authorize]
    public class WorkController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Job()
        {
            return View();
        }

        // Son tutte bloccate, ma permetto a questa di non avere autorizzazioni
        [AllowAnonymous]
        public IActionResult Pubblica()
        {
            return View();
        } 
    }
}
