using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternFactory
{
    internal class Cerchio : IFigura
    {
        private int _id = 0;

        public Cerchio(int id)
        {
            _id = id;
        }

        public void disegna()
        {
            Console.WriteLine("Cerchio con id: " + _id);
        }
    }
}
