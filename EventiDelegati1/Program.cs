namespace EventiDelegati1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Impiegato ugo = new Impiegato("Ugo Fantozzi");
            
            ugo.FinePratica += MetodoFinePraticaImpiegato;
            // posso agganciare più di una callback a FinePratica
            ugo.FinePratica += MetodoFinePraticaImpiegatoFile;

            ugo.EseguiPratica("XXX003");
            ugo.EseguiPratica("WWW455");
            // posso "sganciare" l'ultima callback
            ugo.FinePratica -= MetodoFinePraticaImpiegatoFile;
            //
            ugo.EseguiPratica("QWE333");

            Direttore cobram = new Direttore("Cobram");
            cobram.FinePratica += MetodoFinePraticaDirettore;

            cobram.EseguiPratica("JJ44RR");
            cobram.EseguiPratica("YY99XX");

        }

        // Questo metodo deve combaciare come tipo ritornato e tipi passati con il delegato!
        static void MetodoFinePraticaImpiegato(object o, EventArgs e)
        {
            Console.WriteLine(o.ToString());
        }

        static void MetodoFinePraticaImpiegatoFile(object o, EventArgs e)
        {
            File.AppendAllText("./log.txt", o.ToString() + Environment.NewLine);
        }

        // Callback del Direttore
        static void MetodoFinePraticaDirettore(string msg) // stessa 'firma' del delegato DelegatoDirettore
        {
            Console.WriteLine(msg);
        }
    }
}