using HelloMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HelloMVC.Controllers
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
            // Voglio scrivere il contenuto di una variabile nella pagina html!
            string nome = "Davide";

            // Uso la tipizzazione debole per passare oggetti dal controller all'html
            ViewBag.Nome = nome;  // Creo sul momento la proprietà 'Nome' in ViewBag!
            ViewBag.Cognome = "Orlando";

            Persona p = new Persona();
            p.Nome = "Ugo";
            p.Cognome = "Fantozzi";
            ViewBag.Impiegato = p;

            //Posso anche usare ViewData
            ViewData["Numero"] = 42;

            return View();
        }

        public IActionResult Privacy()
        {
            Persona p = new Persona();
            p.Nome = "Ugo";
            p.Cognome = "Fantozzi";
            List<Persona> persone = new List<Persona>();
            persone.Add(p);
            persone.Add(new Persona { Nome = "Renzo", Cognome = "Filini" });
            persone.Add(new Persona { Nome = "Geometra", Cognome = "Calboni" });

            ViewBag.Elenco = persone;

            return View(); // Va a cercare nella cartella Views la sottocartella Home e il file Privacy.cshtml
        }

        public IActionResult Impiegati()
        {
            // Ora uso la tipizzazione forte per passare un oggetto ad un form html
            List<Persona> direttori = new List<Persona>();
            direttori.Add(new Persona { Nome="Conte", Cognome="Cobram"});
            direttori.Add(new Persona { Nome = "Piermatteo", Cognome = "Semenzara" });
            //Non uso il ViewBag, ma passo l'oggetto direttamente nelle tonde di View!

            //Peò se ho bisogno di altre variabili da passare, posso sempre usare il ViewBag
            return View(direttori);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}