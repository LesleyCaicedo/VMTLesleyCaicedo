using System;
using System.Collections.Generic;

namespace EntityLayer.Models;

public partial class Cash
{
    public int Cashid { get; set; }

    public string? Cashdescription { get; set; }

    public string? Active { get; set; }

    public virtual ICollection<Turn> Turns { get; set; } = new List<Turn>();
}
