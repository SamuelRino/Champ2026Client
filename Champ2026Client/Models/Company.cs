using System;
using System.Collections.Generic;

namespace Champ2026Client.Models;

public partial class Company
{
    public int Id { get; set; }

    public string Company1 { get; set; } = null!;

    public virtual ICollection<VendingMachine> VendingMachines { get; set; } = new List<VendingMachine>();
}
