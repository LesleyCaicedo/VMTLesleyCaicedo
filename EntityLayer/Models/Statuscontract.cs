using System;
using System.Collections.Generic;

namespace EntityLayer.Models;

public partial class Statuscontract
{
    public int Statusid { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
