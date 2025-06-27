using System;
using System.Collections.Generic;

namespace PortfolioTrackerAPI.Data.Models;

public partial class Transaction
{
    public Guid Id { get; set; }

    public Guid AssetId { get; set; }

    public decimal Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal GrossAmount { get; set; }

    public decimal FeeRate { get; set; }

    public decimal Fee { get; set; }

    public decimal NetAmount { get; set; }

    public bool IsBuy { get; set; }

    public decimal RealizedPnL { get; set; }

    public decimal RealizedPnLrate { get; set; }

    public DateOnly CreatedAt { get; set; }

    public string? Note { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Asset Asset { get; set; } = null!;
}
