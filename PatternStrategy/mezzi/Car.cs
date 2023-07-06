using PatternStrategy.algoritmi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternStrategy.mezzi
{
    internal class Car : Vehicle
    {
        public Car(string name) :base(name)
        {
            // Di default l'auto va per strada....
            this.setAlgorithm(new GoByDriving());
        }
    }
}
