using System;
using System.Collections.Generic;

namespace EntityLayer.Models;

public partial class Contract
{
    public int Contractid { get; set; }

    public DateTime? Startdate { get; set; }

    public DateTime? Enddate { get; set; }

    public int? ServiceServiceid { get; set; }

    public string? StatuscontactStatusid { get; set; }

    public int? ClientClientid { get; set; }

    public int? MethodpaymentMethodpaymentid { get; set; }

    public virtual Client? ClientClient { get; set; }

    public virtual Methodpayment? MethodpaymentMethodpayment { get; set; }

    public virtual Servicio? ServiceService { get; set; }

    public virtual Statuscontract? StatuscontactStatus { get; set; }
}
