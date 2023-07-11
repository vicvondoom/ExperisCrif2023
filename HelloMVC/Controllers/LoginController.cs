using HelloMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloMVC.Controllers
{
    public class LoginController : Controller
    {
        // Questa è la action di presentazione del form
        public IActionResult Index()
        {
            return View();
        }

        // Questa è la action di ritorno dal form(di quando si clicca Invio, Submit)
        [HttpPost]
        //Normalmente si preferisce usare i ViewModel invece che un elenco di variabili
        //public IActionResult Index(string username, string password)
        public IActionResult Index(LoginViewModel lvm)
        {
            if(lvm.username=="admin" && lvm.password=="12345")
            {
                ViewBag.Messaggio = "Login effettuato con successo!";
            }
            else
            {
                ViewBag.Messaggio = "Username o password errati!";
            }

            return View();
        }
    }
}
