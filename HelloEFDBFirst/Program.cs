using HelloEFDBFirst.Models;

namespace HelloEFDBFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HelloEfdbfirstContext ctx = new HelloEfdbfirstContext();

            // INSERT
            // Creo un istanza di una classe
            //Persone p = new Persone();
            //p.Nome = "Piermatteo";
            //p.Cognome = "Semenzara";

            //ctx.Persones.Add(p);
            //ctx.SaveChanges();

            //// UPDATE
            //// Linq ('calboni' è un istanza di tipo Persone)
            //var calboni = (from c in ctx.Persones
            //              where c.Id == 3       // Noi cerchiamo per chiave primaria
            //              select c).First();             // Siam sicurissimi che ce ne restituisce uno!
            //calboni.Nome = "Renato";
            //ctx.SaveChanges();

            // DELETE
            //var tizio_da_eliminare = (from c in ctx.Persones
            //                          where c.Id==5
            //                          select c).First();

            //ctx.Persones.Remove(tizio_da_eliminare);
            //ctx.SaveChanges();

            // SELECT
            var elenco = from p in ctx.Persones select p;
            foreach (var p in elenco)
                Console.WriteLine($"{p.Id}\t{p.Nome}\t{p.Cognome}");

            Console.WriteLine("Dato salvato!");
        }
    }
}