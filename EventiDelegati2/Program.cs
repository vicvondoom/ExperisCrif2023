using System.Net.Sockets;

namespace EventiDelegati2
{
    // definisco un delegato
    delegate int Calcolatore(int a, int b);

    internal class Program
    {
        static void Main(string[] args)
        {
            // Voglio usare Matematica e quindi chiamo direttamente i suoi metodi
            int risultato = Matematica.Aggiungi(3, 4);
            risultato = Matematica.Moltiplica(5, 6);
            // uso più volte questa classe

            // un "bel" giorno mi dicono che la classe Matematica è da rimpiazzare
            // con un altra simile..... la NewMath!!
            // devo rimpiazzare la classe e tutte le sue chiamate

            // Ma in partenza, invece che chiamare direttamente i metodi
            // avrei potuto usare un delegato

            // Se devo usare la NewMath, commento queste righe
            //Calcolatore Somma = Matematica.Aggiungi;
            //Calcolatore Moltiplica = Matematica.Moltiplica;
            Calcolatore Somma = NewMath.Add;
            Calcolatore Moltiplica = NewMath.Multiply;

            // il resto del codice non lo cambio più!
            risultato = Somma(3, 4);
            risultato = Moltiplica(5, 6);

            // posso scriverlo in altri modi
            Calcolatore Somma2 = new Calcolatore(NewMath.Add);
            // oppure
            Calcolatore Somma3 = (int a, int b) => Matematica.Aggiungi(a, b);
            // => viene letto 'goes by' in italiano 'diventa'

            // per retrocompatibilità, una delle forme più vecchie di chiamata può essere:
            risultato = Somma.Invoke(3, 4);

        }
    }
}