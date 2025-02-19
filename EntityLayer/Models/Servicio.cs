using System;
using System.Collections.Generic;

namespace EntityLayer.Models;

public partial class Servicio
{
    public int Serviceid { get; set; }

    public string? Servicename { get; set; }

    public string? Servicedescription { get; set; }

    public string? Price { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();
}
