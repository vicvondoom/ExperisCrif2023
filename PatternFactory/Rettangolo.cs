using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternFactory
{
    internal class Rettangolo : IFigura
    {
        private int _id = 0;

        public Rettangolo(int id)
        {
            _id = id;
        }

        public void disegna()
        {
            Console.WriteLine("Rettangolo con id: " + _id);
        }
    }
}
