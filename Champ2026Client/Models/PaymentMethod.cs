using System;
using System.Collections.Generic;

namespace Champ2026Client.Models;

public partial class PaymentMethod
{
    public int Id { get; set; }

    public string? PaymentMethod1 { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
