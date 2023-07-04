using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MieiMetodiEstensione
{
    // 1) deve essere statica
    static class MyExtensionsMethods    // 2) non importa come si chiama
    {
        // 3) 'this string' istruisce il compilatore (ma anche l'intellisense) che
        // ToMaiuscolo verrà a far parte dei metodi di String
        // me lo aggiunge anche se la classe è sealed!
        // 4) E' dichiarato come metodo statico, ma poi lo trovo sull'istanza!
        public static string ToMaiuscolo(this String parola) // <= non è un parametro della ToMaiuscolo!
        {
            return parola.ToUpper();
        }

        // Metodo di estensione che restituisce un numero + 3
        public static int AggiungiTre(this int numero)
        {
            return numero + 3;
        }

        // Metodo che aggiunge un numero + un altro
        public static int AggiungiNumero(this int numero, int altro)
        {
            return numero + altro;
        }
    }
}
