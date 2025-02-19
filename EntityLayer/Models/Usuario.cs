using System;
using System.Collections.Generic;

namespace EntityLayer.Models;

public partial class Usuario
{
    public int Userid { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? RolRolid { get; set; }

    public DateTime? Creationdate { get; set; }

    public int? Usercreate { get; set; }

    public int? Userapproval { get; set; }

    public DateTime? Datespproval { get; set; }

    public string? UserstatusStatusid { get; set; }

    public virtual Rol? RolRol { get; set; }

    public virtual Userstatus? UserstatusStatus { get; set; }
}
