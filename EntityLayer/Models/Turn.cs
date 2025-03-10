﻿using System;
using System.Collections.Generic;

namespace EntityLayer.Models;

public partial class Turn
{
    public int Turnid { get; set; }

    public string? Description { get; set; }

    public DateTime? Date { get; set; }

    public int? CashCashid { get; set; }

    public int? Usergestorid { get; set; }

    public virtual ICollection<Attention> Attentions { get; set; } = new List<Attention>();

    public virtual Cash? CashCash { get; set; }
}
