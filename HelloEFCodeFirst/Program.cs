using HelloEFCodeFirst.Models;

namespace HelloEFCodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Istanzio il db context
            AziendaContext ctx = new AziendaContext();

            // Creo una categoria
            Categoria categoria = new Categoria();
            categoria.Descrizione = "Bevande";
            ctx.Categorie.Add(categoria);
            //ctx.Add(categoria);
            ctx.SaveChanges();
            // Dop oquesta SaveChanges trovo l'ID PK valorizzato!

            // Creo un prodotto e lo metto in una categoria
            Prodotto p = new Prodotto();
            p.Codice = "001";
            p.Descrizione = "Coca Cola";
            p.Prezzo = 2.5;
            p.ID_Categoria = categoria.Id;
            ctx.Prodotti.Add(p);
            ctx.SaveChanges();



            Console.WriteLine("Categoria e prodotto salvati!");
            

        }
    }
}