using System;
using System.Collections.Generic;

namespace BibliotecaAPI.Models;

public partial class Editori
{
    public int Id { get; set; }

    public string Descrizione { get; set; } = null!;

    public string Sede { get; set; } = null!;

    public virtual ICollection<Libri> Libris { get; set; } = new List<Libri>();
}
