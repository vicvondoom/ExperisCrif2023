using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDecorator
{
    // Classe su cui ogni decoratore si basa
    abstract class ComputerDecorator : Computer
    {
        public abstract override string Descrizione();
        public abstract override int Prezzo();
    }
}
