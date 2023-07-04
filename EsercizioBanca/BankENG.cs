using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioBanca
{
    internal class BankENG
    {
        private int _saldo = 0;

        public int Balance()
        {
            return _saldo;
        }

        public bool PickUp(int soldi)
        {
            if (_saldo - soldi > 0)
            {
                _saldo -= soldi;
                return true;
            }
            else
                return false;
        }

        public void Deposit(int soldi)
        {
            _saldo += soldi;
        }
    }
}
