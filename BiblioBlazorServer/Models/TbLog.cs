using System;
using System.Collections.Generic;

namespace BiblioBlazorServer.Models;

public partial class TbLog
{
    public int Id { get; set; }

    public string? Message { get; set; }

    public string? Level { get; set; }

    public DateTime? TimeStamp { get; set; }

    public string? Exception { get; set; }
}
