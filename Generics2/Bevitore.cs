using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics2
{
    internal class Bevitore
    {
        private string _nome = "";

        public Bevitore(string nome)
        {
            _nome = nome;
        }

        //// Prima soluzione: overload del metodo 'Bevi' che accetta la caraffa
        //public string Beve<T>(Bottiglia<T> bottiglia) where T : IBevanda
        //{
        //    return $"Mi chiamo {_nome} e sto bevendo {bottiglia}";
        //}

        //public string Beve<T>(Caraffa<T> bottiglia) where T : IBevanda
        //{
        //    return $"Mi chiamo {_nome} e sto bevendo {bottiglia}";
        //}

        // Seconda soluzione
        public string Beve<T>(IContenitore contenitore) where T : IBevanda
        {
            return $"Mi chiamo {_nome} e sto bevendo {contenitore}";
        }
    }
}
