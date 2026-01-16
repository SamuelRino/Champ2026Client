using System;
using System.Collections.Generic;

namespace Champ2026Client.Models;

public partial class WorkMode
{
    public int Id { get; set; }

    public string WorkMode1 { get; set; } = null!;

    public virtual ICollection<VendingMachine> VendingMachines { get; set; } = new List<VendingMachine>();
}
