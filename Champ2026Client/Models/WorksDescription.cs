using System;
using System.Collections.Generic;

namespace Champ2026Client.Models;

public partial class WorksDescription
{
    public int Id { get; set; }

    public string? WorkDescription { get; set; }

    public virtual ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();
}
