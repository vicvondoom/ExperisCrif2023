using System;
using System.Collections.Generic;

namespace HelloEFDBFirst.Models;

public partial class Persone
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;
}
