using System;
using System.Collections.Generic;

namespace PortfolioTrackerAPI.Models;

public partial class Investor
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();
}
