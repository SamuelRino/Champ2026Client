using System;
using System.Collections.Generic;

namespace Champ2026Client.Models;

public partial class User
{
    public string Id { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public bool IsManager { get; set; }

    public bool IsEngineer { get; set; }

    public bool IsOperator { get; set; }

    public string Phone { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string Image { get; set; } = null!;

    public virtual ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();

    public virtual ICollection<UserLogin> UserLogins { get; set; } = new List<UserLogin>();

    public virtual ICollection<VendingMachine> VendingMachineEngineers { get; set; } = new List<VendingMachine>();

    public virtual ICollection<VendingMachine> VendingMachineManagers { get; set; } = new List<VendingMachine>();

    public virtual ICollection<VendingMachine> VendingMachineTechnicians { get; set; } = new List<VendingMachine>();

    public virtual ICollection<VendingMachine> VendingMachineUsers { get; set; } = new List<VendingMachine>();
}
