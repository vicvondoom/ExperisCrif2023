using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDecorator
{
    // Classe base della catena dei decoratori
    internal class Computer
    {
        private string _descrizione = "Computer base";
        private int _prezzo = 300;

        public virtual string Descrizione()
        {
            return _descrizione;
        }

        public virtual int Prezzo()
        {
            return _prezzo;
        }
    }
}
