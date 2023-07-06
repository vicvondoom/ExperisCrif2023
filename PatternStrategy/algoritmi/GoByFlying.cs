using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternStrategy.algoritmi
{
    internal class GoByFlying : IGo
    {
        public void Go()
        {
            Console.WriteLine("sto volando ..");
        }
    }
}
