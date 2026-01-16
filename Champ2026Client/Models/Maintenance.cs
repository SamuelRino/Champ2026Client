using System;
using System.Collections.Generic;

namespace Champ2026Client.Models;

public partial class Maintenance
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int? IssuesFound { get; set; }

    public string? VendingMachineId { get; set; }

    public string? UserId { get; set; }

    public int WorkDescription { get; set; }

    public virtual IssuesFound? IssuesFoundNavigation { get; set; }

    public virtual User? User { get; set; }

    public virtual VendingMachine? VendingMachine { get; set; }

    public virtual WorksDescription WorkDescriptionNavigation { get; set; } = null!;
}
