using PatternStrategy.algoritmi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternStrategy.mezzi
{
    internal class Helicopter : Vehicle
    {
        public Helicopter(string name) : base(name)
        {
            // Di default l'elicottero vola....
            this.setAlgorithm(new GoByFlying());
        }
    }
}