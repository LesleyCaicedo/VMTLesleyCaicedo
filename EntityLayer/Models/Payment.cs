using System;
using System.Collections.Generic;

namespace EntityLayer.Models;

public partial class Payment
{
    public int Paymentid { get; set; }

    public DateTime? Paymentdate { get; set; }

    public int? ClientClientid { get; set; }

    public virtual Client? ClientClient { get; set; }
}
