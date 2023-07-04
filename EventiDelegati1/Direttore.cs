using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventiDelegati1
{
    // Dichiaro un mio delegato
    public delegate void DelegatoDirettore(string messaggio); // invece che EventHandler.....

    internal class Direttore
    {
        private string _nome;
        private int _pratichefatte = 0;

        // dichiaro un evento ma del tipo di delegato che voglio io!
        public event DelegatoDirettore FinePratica;

        public Direttore(string nome)
        {
            _nome = nome;
        }

        public void EseguiPratica(string codicePratica)
        {
            // In qualche modo il direttore fà la pratica....
            _pratichefatte++;
            // Voglio chiamare quella funzione, ma prima controllo che non sia null...
            if (FinePratica != null)
            {
                // Dato che object, il primo parametro, è una qualsiasi classe di NET, gli passo una stringa
                FinePratica($"Il direttore {_nome} ha finito la pratica: {codicePratica}");
            }
        }
    }
}
