using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDecorator
{
    internal class Ram8Gb : ComputerDecorator
    {
        private Computer _computer;

        private string _descrizione = "RAM 8 Gb";
        private int _prezzo = 90;

        public Ram8Gb(Computer computer)
        {
            _computer = computer;
        }

        public override string Descrizione()
        {
            return this._computer.Descrizione() + " e " + this._descrizione;
        }

        public override int Prezzo()
        {
            return this._computer.Prezzo() + this._prezzo;
        }
    }
}
