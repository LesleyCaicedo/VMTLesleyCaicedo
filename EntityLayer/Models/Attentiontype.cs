using System;
using System.Collections.Generic;

namespace EntityLayer.Models;

public partial class Attentiontype
{
    public string Attentiontypeid { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Attention> Attentions { get; set; } = new List<Attention>();
}
