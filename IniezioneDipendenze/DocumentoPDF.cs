﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IniezioneDipendenze
{
    internal class DocumentoPDF : IDocumento
    {
        public string getContent()
        {
            return "Testo del documento PDF";
        }
    }
}
