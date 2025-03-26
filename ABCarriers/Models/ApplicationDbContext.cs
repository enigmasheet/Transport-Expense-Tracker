using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ABCarriers.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    public virtual DbSet<view_report> ViewReports { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Category__3213E83F0F657FD1");

            entity.ToTable("Category");

            entity.HasIndex(e => e.name, "UQ__Category__72E12F1B6EFFBA55").IsUnique();

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.description).HasColumnType("text");
            entity.Property(e => e.name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.updated_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Invoice__3213E83FC5B0C76E");

            entity.ToTable("Invoice", tb => tb.HasTrigger("trg_invoice_update"));

            entity.HasIndex(e => e.invoice_no, "UQ__Invoice__F58CA1E22B1F8B67").IsUnique();

            entity.HasIndex(e => e.category_id, "idx_invoice_category");

            entity.HasIndex(e => e.invoice_no, "idx_invoice_invoice_no");

            entity.HasIndex(e => e.vendor_id, "idx_invoice_vendor");

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.invoice_no)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.quantity).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.rate).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.taxable_amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.total_amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.updated_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.vat_amount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.category).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.category_id)
                .HasConstraintName("FK__Invoice__categor__0F2D40CE");

            entity.HasOne(d => d.unit).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.unit_id)
                .HasConstraintName("FK__Invoice__unit_id__1209AD79");

            entity.HasOne(d => d.vendor).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.vendor_id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Invoice__vendor___0E391C95");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Location__3213E83FB18E8BF8");

            entity.ToTable("Location");

            entity.HasIndex(e => e.name, "UQ__Location__72E12F1B463DB499").IsUnique();

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.updated_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Unit__3213E83F1C773AD7");

            entity.ToTable("Unit");

            entity.HasIndex(e => e.name, "UQ__Unit__72E12F1BD513A62A").IsUnique();

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.description).HasColumnType("text");
            entity.Property(e => e.name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.updated_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Vendor__3213E83F6163C237");

            entity.ToTable("Vendor", tb => tb.HasTrigger("trg_vendor_update"));

            entity.HasIndex(e => e.vat_no, "UQ__Vendor__B444FCAAD98A0396").IsUnique();

            entity.HasIndex(e => e.location_id, "idx_vendor_location");

            entity.Property(e => e.contact)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.created_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.updated_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.vat_no)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.location).WithMany(p => p.Vendors)
                .HasForeignKey(d => d.location_id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Vendor__location__73852659");
        });

        modelBuilder.Entity<view_report>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("view_report");

            entity.Property(e => e.category_name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.created_at).HasColumnType("datetime");
            entity.Property(e => e.invoice_no)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.location_name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.quantity).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.rate).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.taxable_amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.total_amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.unit_name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.updated_at).HasColumnType("datetime");
            entity.Property(e => e.vat_amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.vat_no)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
