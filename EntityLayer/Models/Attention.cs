using System;
using System.Collections.Generic;

namespace EntityLayer.Models;

public partial class Attention
{
    public int Attentionid { get; set; }

    public int? TurnTurnid { get; set; }

    public int? ClientClientid { get; set; }

    public string? AttentiontypeAttentiontypeid { get; set; }

    public int? AttentionstatusStatusid { get; set; }

    public virtual Attentionstatus? AttentionstatusStatus { get; set; }

    public virtual Attentiontype? AttentiontypeAttentiontype { get; set; }

    public virtual Client? ClientClient { get; set; }

    public virtual Turn? TurnTurn { get; set; }
}
