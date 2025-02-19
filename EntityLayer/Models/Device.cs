using System;
using System.Collections.Generic;

namespace EntityLayer.Models;

public partial class Device
{
    public int Deviceid { get; set; }

    public string? Devicename { get; set; }

    public int? ServiceServiceid { get; set; }

    public virtual Servicio? ServiceService { get; set; }
}
