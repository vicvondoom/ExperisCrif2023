using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics2
{
    internal class Caraffa<T> : IContenitore where T : IBevanda
    {
        private T _contenuto;

        public Caraffa(T contenuto)
        {
            _contenuto = contenuto;
        }

        public override string ToString()
        {
            return "una caraffa di " + _contenuto;
        }
    }
}
