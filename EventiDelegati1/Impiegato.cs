using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventiDelegati1
{
    internal class Impiegato
    {
        private string _nome;
        private int _pratichefatte = 0;

        // Mi faccio dare qualcosa da chiamare quando ho finito la pratica
        // Ho dichiarato un evento con un tipo pre-esistente e un nome
        public event EventHandler FinePratica;


        public Impiegato(string nome)
        {
            this._nome = nome;
        }

        public void EseguiPratica(string codicePratica)
        {
            // In qualche modo l'impiegato fà la pratica....
            _pratichefatte++;
            // Voglio chiamare quella funzione, ma prima controllo che non sia null...
            if(FinePratica != null)
            {
                // Dato che object, il primo parametro, è una qualsiasi classe di NET, gli passo una stringa
                FinePratica(_nome + " ha finito la pratica: " + codicePratica, EventArgs.Empty);
            }
        }
    }
}
