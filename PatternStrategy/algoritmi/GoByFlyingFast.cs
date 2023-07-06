using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternStrategy.algoritmi
{
    internal class GoByFlyingFast : IGo
    {
        public void Go()
        {
            Console.WriteLine("sto volando molto velocemente!!");
        }
    }
}
