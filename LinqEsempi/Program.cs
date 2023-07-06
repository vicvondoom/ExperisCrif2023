namespace LinqEsempi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numeri = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            // voglio trovare tutti i pari di questa lista
            List<int> pari = new List<int>();
            foreach(int n in numeri)
            {
                if(n%2 == 0)
                    pari.Add(n);
            }

            // Uso Linq
            var pari2 = (from n in numeri where n%2 == 0 select n).ToList();
            // Uso le lambda expression
            var pari3 = numeri.Where(n => n%2 == 0).ToList();

            List<string> nomi = new List<string>() { "Davide", "Marco", "Giovanna", "Michele", "Paolo" };
            // Tutti i nomi che iniziano con 'M'
            var nomiM = from nome in nomi where nome.StartsWith("M") select nome;
            // lambda
            var nomiM2 = nomi.Where(nome => nome.StartsWith("M"));

            // Mi creo una lista di prodotti
            List<Prodotto> prodotti = new List<Prodotto>();
            prodotti.Add(new Prodotto { ID = 1, Codice = "NUT", Descrizione = "Nutella", Prezzo = 5 });
            prodotti.Add(new Prodotto { ID = 2, Codice = "SUG", Descrizione = "Sugo", Prezzo = 3 });
            prodotti.Add(new Prodotto { ID = 3, Codice = "LAT", Descrizione = "Latte scremato", Prezzo = 2 });
            prodotti.Add(new Prodotto { ID = 4, Codice = "GEL", Descrizione = "Gelato al cioccolato", Prezzo = 7 });
            prodotti.Add(new Prodotto { ID = 5, Codice = "BIS", Descrizione = "Bistecche", Prezzo = 12 });

            // tutti quelli che finiscono per 'o'
            var prods = from p in prodotti
                        where p.Descrizione.EndsWith("o")
                        select p;
            // tutti quelli che hanno prezzo tra 2 e 4
            var prods2 = from p in prodotti
                         where p.Prezzo >= 2 && p.Prezzo <= 4
                         select p;

            // con lambda
            var prods3 = prodotti.Where(p => p.Prezzo >= 2 && p.Prezzo <= 4);

            // voglio il codice del prodotto più costoso
            var costoso = (from p in prodotti
                           orderby p.Prezzo descending
                           select p).First().Codice;
            // stessa di sopra con lambda exp
            var costoso2 = prodotti.OrderByDescending(p => p.Prezzo).First().Codice;

        }
    }
}