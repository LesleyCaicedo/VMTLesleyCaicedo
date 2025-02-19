using System;
using System.Collections.Generic;

namespace EntityLayer.Models;

public partial class Attentionstatus
{
    public int Statusid { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Attention> Attentions { get; set; } = new List<Attention>();
}
