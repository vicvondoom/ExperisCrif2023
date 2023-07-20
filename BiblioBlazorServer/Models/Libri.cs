using System;
using System.Collections.Generic;

namespace BiblioBlazorServer.Models;

public partial class Libri
{
    public int Id { get; set; }

    public string Titolo { get; set; } = null!;

    public double Prezzo { get; set; }

    public int IdAutore { get; set; }

    public int? IdEditore { get; set; }

    public virtual Autori IdAutoreNavigation { get; set; } = null!;

    public virtual Editori? IdEditoreNavigation { get; set; }
}
