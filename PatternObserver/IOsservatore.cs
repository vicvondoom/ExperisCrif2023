using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternObserver
{
    internal interface IOsservatore
    {
        void Aggiorna(string s);
    }
}
