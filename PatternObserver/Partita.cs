using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternObserver
{
    internal class Partita
    {
        private string _nome = "";
        private string _messaggio = "";
        private List<IOsservatore> osservatori = new List<IOsservatore>();

        public Partita(string nome)
        {
            _nome = nome;
            this._messaggio = "0-0";
        }

        public void addOsservatore(IOsservatore osservatore)
        {
            this.osservatori.Add(osservatore);
            osservatore.Aggiorna(this._messaggio);
        }

        public void removeOsservatore(IOsservatore osservatore)
        {
            this.osservatori.Remove(osservatore);
        }

        public void Notifica(string messaggio)
        {
            this._messaggio = messaggio;
            foreach(var o in this.osservatori)
            {
                o.Aggiorna(messaggio);
            }
        }
    }
}
