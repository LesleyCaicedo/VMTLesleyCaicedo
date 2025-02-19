using System;
using System.Collections.Generic;

namespace EntityLayer.Models;

public partial class Userstatus
{
    public string Statusid { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
