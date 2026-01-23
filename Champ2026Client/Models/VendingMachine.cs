using System;
using System.Collections.Generic;

namespace Champ2026Client.Models;

public partial class VendingMachine
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public int ModelId { get; set; }

    public bool CoinAcceptor { get; set; }

    public bool BillAcceptor { get; set; }

    public bool CashlessPayment { get; set; }

    public bool QrPayment { get; set; }

    public decimal TotalIncome { get; set; }

    public int SerialNumber { get; set; }

    public int? InventNumber { get; set; }

    public DateTime? ManufactureDate { get; set; }

    public DateTime InstallDate { get; set; }

    public DateTime? SystemDate { get; set; }

    public DateTime LastMaintenanceDate { get; set; }

    public int? InterverificationInterval { get; set; }

    public int? VmResource { get; set; }

    public DateTime? NextMaintenanceDate { get; set; }

    public DateTime? InventoryDate { get; set; }

    public int StatusId { get; set; }

    public string UserId { get; set; } = null!;

    public string RfidCashCollection { get; set; } = null!;

    public string RfidLoading { get; set; } = null!;

    public string RfidService { get; set; } = null!;

    public string? Notes { get; set; }

    public int WorkModeId { get; set; }

    public string KitOnlineId { get; set; } = null!;

    public int CompanyId { get; set; }

    public int? CriticalTresholdTemplateId { get; set; }

    public int ServicePriorityId { get; set; }

    public string ManagerId { get; set; } = null!;

    public string EngineerId { get; set; } = null!;

    public string TechnicianId { get; set; } = null!;

    public int? NotificationTemplateId { get; set; }

    public string WorkingHours { get; set; } = null!;

    public string Place { get; set; } = null!;

    public int OperatorId { get; set; }

    public string Coordinates { get; set; } = null!;

    public int Timezone { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual CriticalThresholdTemplate? CriticalTresholdTemplate { get; set; }

    public virtual User Engineer { get; set; } = null!;

    public virtual ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();

    public virtual User Manager { get; set; } = null!;

    public virtual Model Model { get; set; } = null!;

    public virtual NotificationTemplate? NotificationTemplate { get; set; }

    public virtual Operator Operator { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ServicePriority ServicePriority { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual User Technician { get; set; } = null!;

    public virtual Timezone TimezoneNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual WorkMode WorkMode { get; set; } = null!;
}
