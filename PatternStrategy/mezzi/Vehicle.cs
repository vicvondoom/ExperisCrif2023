using PatternStrategy.algoritmi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternStrategy.mezzi
{
    abstract class Vehicle : IGo
    {
        private IGo _algorithm;
        private string _name;

        protected Vehicle(string name)
        {
            _name = name;
        }

        public void setAlgorithm(IGo algorithm)
        {
            _algorithm = algorithm;
        }

        public void Go()
        {
            Console.Write(this._name + ": ");
            this._algorithm.Go();
        }
    }
}
