using System;
using System.Collections.Generic;

namespace EntityLayer.Models;

public partial class Usercash
{
    public int? UserUserid { get; set; }

    public int? CashCashid { get; set; }

    public virtual Cash? CashCash { get; set; }

    public virtual Usuario? UserUser { get; set; }
}
