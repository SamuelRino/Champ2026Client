using System;
using System.Collections.Generic;

namespace Champ2026Client.Models;

public partial class IssuesFound
{
    public int Id { get; set; }

    public string? IssueFound { get; set; }

    public virtual ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();
}
