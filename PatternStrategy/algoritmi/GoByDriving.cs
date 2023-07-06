using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternStrategy.algoritmi
{
    internal class GoByDriving : IGo
    {
        public void Go()
        {
            Console.WriteLine("sto guidando su strada..");
        }
    }
}
