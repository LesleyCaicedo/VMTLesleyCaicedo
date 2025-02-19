using System;
using System.Collections.Generic;

namespace EntityLayer.Models;

public partial class Rol
{
    public int Rolid { get; set; }

    public string? Rolname { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
