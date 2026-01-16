using System;
using System.Collections.Generic;

namespace Champ2026Client.Models;

public partial class Operator
{
    public int Id { get; set; }

    public string? Operator1 { get; set; }

    public virtual ICollection<VendingMachine> VendingMachines { get; set; } = new List<VendingMachine>();
}
