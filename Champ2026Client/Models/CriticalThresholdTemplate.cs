using System;
using System.Collections.Generic;

namespace Champ2026Client.Models;

public partial class CriticalThresholdTemplate
{
    public int Id { get; set; }

    public string Template { get; set; } = null!;

    public virtual ICollection<VendingMachine> VendingMachines { get; set; } = new List<VendingMachine>();
}
