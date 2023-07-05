using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternFactory
{
    internal class Quadrato : IFigura
    {
        private int _id = 0;

        public Quadrato(int id)
        {
            _id = id;
        }

        public void disegna()
        {
            Console.WriteLine("Quadrato con id: " + _id);
        }
    }
}
