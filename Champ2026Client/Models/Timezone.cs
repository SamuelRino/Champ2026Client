using System;
using System.Collections.Generic;

namespace Champ2026Client.Models;

public partial class Timezone
{
    public int Id { get; set; }

    public string? Timezone1 { get; set; }

    public virtual ICollection<VendingMachine> VendingMachines { get; set; } = new List<VendingMachine>();
}
