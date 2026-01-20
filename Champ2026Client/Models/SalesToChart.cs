using System;
using System.Collections.Generic;

namespace Champ2026Client.Models;

public partial class SalesToChart
{
    public DateOnly? Date { get; set; }

    public decimal? TotalPrice { get; set; }

    public int? SalesCount { get; set; }
}
