using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IniezioneDipendenze
{
    internal class Stampante
    {
        // Mi disaccoppio il più possibile dalle classi concrete
        public void Stampa(IDocumento doc)
        {
            Console.WriteLine("Sto mandando in stampa il contenuto: " + doc.getContent());
        }

        //public void Stampa(DocumentoWord doc)
        //{
        //    // Ipotizziamo di mandare in stampa
        //    Console.WriteLine("Sto mandando in stampa il contenuto: " + doc.getContent());
        //}

        //public void Stampa(DocumentoPDF pdf)
        //{
        //    Console.WriteLine("Sto mandando in stampa il contenuto: " + pdf.prendiContenuto());
        //}
    }
}
