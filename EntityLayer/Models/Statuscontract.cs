using System;
using System.Collections.Generic;

namespace EntityLayer.Models;

public partial class Statuscontract
{
    public string Statusid { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
