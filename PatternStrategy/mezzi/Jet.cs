using PatternStrategy.algoritmi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternStrategy.mezzi
{
    internal class Jet : Vehicle
    {
        public Jet(string name) : base(name)
        {
            // Di default il jet vola veloce....
            this.setAlgorithm(new GoByFlyingFast());
        }
    }
}