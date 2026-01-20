using System;
using System.Collections.Generic;

namespace Champ2026Client.Models;

public partial class Sale
{
    public int Id { get; set; }

    public DateTime Timestamp { get; set; }

    public string ProductId { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public int Quantity { get; set; }

    public int PaymentMethodId { get; set; }

    public virtual PaymentMethod PaymentMethod { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
