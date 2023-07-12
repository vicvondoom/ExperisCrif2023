using Microsoft.AspNetCore.Mvc;
using NegozioMusicaWeb.Models;
using System.Diagnostics;

namespace NegozioMusicaWeb.Controllers
{
    public class HomeController : Controller
    {
        private MusicaContext _ctx;

        // Recupero dal sistema, chiamandola dal costruttore, l'istanza che mi serve
        public HomeController(MusicaContext ctx)
        {
            this._ctx = ctx;
        }

        public IActionResult Index()
        {
            // Qui voglio un elenco di prodotti, mi basterebbe istanziare il db context
            //MusicaContext ctx = new MusicaContext(options => options.UseSqlServer(""))
            // Non faccio come sopra poichè sprecherei risorse!

            // Uso l'istanza iniettata nel Program.cs
            var prodotti = _ctx.Prodotti.ToList();

            ViewBag.NumProdotti = prodotti.Count;

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