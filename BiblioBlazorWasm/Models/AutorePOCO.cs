using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioBlazorWasm.Models
{
    public class AutorePOCO
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        public string Cognome { get; set; } = null!;
    }
}
