using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdottiController : ControllerBase
    {
        private List<Prodotto> list = new List<Prodotto>();

        public ProdottiController()
        {
            list.Add(new Prodotto { Id = 1, Descrizione = "Pasta De Cecco", Prezzo = 4 });
            list.Add(new Prodotto { Id = 2, Descrizione = "Latte Granarolo", Prezzo = 2 });
            list.Add(new Prodotto { Id = 3, Descrizione = "Cotolette Aia", Prezzo = 7 });
            list.Add(new Prodotto { Id = 4, Descrizione = "Birra Moretti", Prezzo = 3 });
        }

        // Lista di prodotti
        [HttpGet]
        public List<Prodotto> Elenco()
        {
            return list;
        }

        [HttpGet("{id}")]
        public Prodotto Dettaglio(int id)
        {
            return list.Where(p => p.Id == id).First();
        }

        [HttpPost]
        public int Inserisci(Prodotto prod)
        {
            list.Add(prod);
            return list.Count;
        }

        [HttpPut("{id}")]
        public string Modifica(int id, Prodotto prod)
        {
            return "Modificato " + prod.Descrizione + " con id: " + id;
        }

        [HttpDelete("{id}")]
        public string Elimina(int id)
        {
            return "Eliminato prodotto con id: " + id;
        }
    }
}
