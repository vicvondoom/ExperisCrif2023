using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics1
{
    // Parametrizzo questa classe conun tipo di dato
    // ma posso vincolare in alcuni modi
    // where T :
    // class                accetta solo classi
    // struct               accetta solo struct
    // new()                accetta solo classi che hanno il costruttore vuoto!
    // Interfaccia          accetta solo oggetti che implementano Interfaccia
    internal class Bidone<T> where T : IList
    {
        public T Contenuto { get; set; }

        public Bidone(T contenuto)
        {
            this.Contenuto = contenuto;
        }
    }
}
