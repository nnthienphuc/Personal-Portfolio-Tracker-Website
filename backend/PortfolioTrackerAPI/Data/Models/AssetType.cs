using System;
using System.Collections.Generic;

namespace PortfolioTrackerAPI.Data.Models;

public partial class AssetType
{
    public Guid Id { get; set; }

    public string TypeCode { get; set; } = null!;

    public string TypeName { get; set; } = null!;

    public string? Note { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();
}
