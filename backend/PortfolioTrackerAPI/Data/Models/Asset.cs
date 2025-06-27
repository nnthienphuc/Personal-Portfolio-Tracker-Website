using System;
using System.Collections.Generic;

namespace PortfolioTrackerAPI.Data.Models;

public partial class Asset
{
    public Guid Id { get; set; }

    public string Symbol { get; set; } = null!;

    public string Name { get; set; } = null!;

    public Guid InvestorId { get; set; }

    public Guid AssetTypeId { get; set; }

    public decimal AvgUnitPrice { get; set; }

    public decimal CurrentQuantity { get; set; }

    public decimal CurrentMarketPrice { get; set; }

    public decimal TotalInvestedValue { get; set; }

    public decimal CurrentPnLrate { get; set; }

    public decimal TargetBuyPrice { get; set; }

    public decimal TargetSellPrice { get; set; }

    public decimal TargetPnLrate { get; set; }

    public DateOnly CreatedAt { get; set; }

    public DateOnly UpdatedAt { get; set; }

    public string? Note { get; set; }

    public bool IsDeleted { get; set; }

    public virtual AssetType AssetType { get; set; } = null!;

    public virtual Investor Investor { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
