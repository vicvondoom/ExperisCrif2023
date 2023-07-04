using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics2
{
    internal class Bottiglia<T> : IContenitore where T : IBevanda
    {
        private T _contenuto;

        public Bottiglia(T contenuto)
        {
            _contenuto = contenuto;
        }

        public override string ToString()
        {
            return "una bottiglia di " + _contenuto;
        }
    }
}
