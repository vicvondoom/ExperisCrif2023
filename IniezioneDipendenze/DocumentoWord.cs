using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IniezioneDipendenze
{
    internal class DocumentoWord : IDocumento
    {
        // Metodo fake che presuppone di estrarre il contenuto di un doc Word e ritornarcelo
        public string getContent()
        {
            return "Testo del documento Word...";
        }
    }
}
