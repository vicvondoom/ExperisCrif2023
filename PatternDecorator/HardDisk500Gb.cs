using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDecorator
{
    internal class HardDisk500Gb : ComputerDecorator
    {
        private Computer _computer;

        private string _descrizione = "Hard Disk 500Gb";
        private int _prezzo = 80;

        public HardDisk500Gb(Computer computer)
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
