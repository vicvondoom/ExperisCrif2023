using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioBanca
{
    internal class BancaITA
    {
        private int _saldo = 0;

        public int Saldo()
        {
            return _saldo;
        }

        public bool Preleva(int soldi)
        {
            if (_saldo - soldi > 0)
            {
                _saldo -= soldi;
                return true;
            }
            else
                return false;
        }

        public void Deposita(int soldi)
        {
            _saldo += soldi;
        }
    }
}
