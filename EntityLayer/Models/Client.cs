﻿using System;
using System.Collections.Generic;

namespace EntityLayer.Models;

public partial class Client
{
    public int Clientid { get; set; }

    public string? Name { get; set; }

    public string? Lastname { get; set; }

    public string? Identification { get; set; }

    public string? Email { get; set; }

    public string? Phonenumber { get; set; }

    public string? Address { get; set; }

    public string? Referenceaddress { get; set; }

    public int? contractid { get; set; }

    public virtual ICollection<Attention> Attentions { get; set; } = new List<Attention>();

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public DateTime? Startdate { get; set; }

    public DateTime? Enddate { get; set; }

    public string? Servicename { get; set; }

    public string? Price { get; set; }

    public string? FormaPago { get; set; }

    public string? EstadoContrato { get; set; }

}
