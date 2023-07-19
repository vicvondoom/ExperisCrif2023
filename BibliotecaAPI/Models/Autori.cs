using System;
using System.Collections.Generic;

namespace BibliotecaAPI.Models;

public partial class Autori
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public virtual ICollection<Libri> Libris { get; set; } = new List<Libri>();
}
