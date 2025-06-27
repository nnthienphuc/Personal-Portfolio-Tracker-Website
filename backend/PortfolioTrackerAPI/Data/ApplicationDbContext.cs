using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PortfolioTrackerAPI.Models;

namespace PortfolioTrackerAPI.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asset> Assets { get; set; }

    public virtual DbSet<AssetType> AssetTypes { get; set; }

    public virtual DbSet<Investor> Investors { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=PORTFOLIO_TRACKER_API;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asset>(entity =>
        {
            entity.HasIndex(e => new { e.Symbol, e.InvestorId }, "IX_Assets").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AvgUnitPrice).HasColumnType("decimal(8, 4)");
            entity.Property(e => e.CurrentMarketPrice).HasColumnType("decimal(8, 4)");
            entity.Property(e => e.CurrentPnLrate)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("CurrentPnLRate");
            entity.Property(e => e.CurrentQuantity).HasColumnType("decimal(12, 4)");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Symbol)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TargetBuyPrice).HasColumnType("decimal(8, 4)");
            entity.Property(e => e.TargetPnLrate)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("TargetPnLRate");
            entity.Property(e => e.TargetSellPrice).HasColumnType("decimal(8, 4)");
            entity.Property(e => e.TotalInvestedValue).HasColumnType("decimal(15, 4)");

            entity.HasOne(d => d.AssetType).WithMany(p => p.Assets)
                .HasForeignKey(d => d.AssetTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assets_AssetTypes");

            entity.HasOne(d => d.Investor).WithMany(p => p.Assets)
                .HasForeignKey(d => d.InvestorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assets_Investors");
        });

        modelBuilder.Entity<AssetType>(entity =>
        {
            entity.HasIndex(e => e.TypeCode, "IX_TypeCode").IsUnique();

            entity.HasIndex(e => e.TypeName, "IX_TypeName").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.TypeCode)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.TypeName).HasMaxLength(15);
        });

        modelBuilder.Entity<Investor>(entity =>
        {
            entity.HasIndex(e => e.Email, "IX_Email").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Fee).HasColumnType("decimal(8, 4)");
            entity.Property(e => e.FeeRate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.GrossAmount).HasColumnType("decimal(15, 4)");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(15, 4)");
            entity.Property(e => e.Quantity).HasColumnType("decimal(12, 4)");
            entity.Property(e => e.RealizedPnL).HasColumnType("decimal(8, 4)");
            entity.Property(e => e.RealizedPnLrate)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("RealizedPnLRate");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(8, 4)");

            entity.HasOne(d => d.Asset).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.AssetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transactions_Assets");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
