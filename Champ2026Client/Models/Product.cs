using System;
using System.Collections.Generic;

namespace Champ2026Client.Models;

public partial class Product
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public int? MinStock { get; set; }

    public string? VendingMachineId { get; set; }

    public string? Description { get; set; }

    public int? QuantityAvailable { get; set; }

    public decimal? SalesTrend { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual VendingMachine? VendingMachine { get; set; }
}
