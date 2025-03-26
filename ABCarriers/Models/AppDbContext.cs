using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ABCarriers.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    // No need to configure connection string here as it is done in DI
    //    base.OnConfiguring(optionsBuilder);
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3213E83F13F8544B");

            entity.ToTable("Category");

            entity.HasIndex(e => e.Name, "UQ__Category__72E12F1BFEAB4084").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Invoice__3213E83F5F1A4E68");

            entity.ToTable("Invoice");

            entity.HasIndex(e => e.InvoiceNo, "UQ__Invoice__F58CA1E2FF83E40B").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.InvoiceNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("invoice_no");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.Miti).HasColumnName("miti");
            entity.Property(e => e.VendorId).HasColumnName("vendor_id");

            entity.HasOne(d => d.Category).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Invoice__categor__498EEC8D");

            entity.HasOne(d => d.Location).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Invoice__locatio__489AC854");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Invoice__vendor___47A6A41B");
        });

        modelBuilder.Entity<InvoiceItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InvoiceI__3213E83FE0FF9FBE");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.Quantity)
                .HasDefaultValue(1)
                .HasColumnName("quantity");
            entity.Property(e => e.Rate)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("rate");
            entity.Property(e => e.TaxableAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("taxable_amount");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_amount");
            entity.Property(e => e.VatAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("vat_amount");

            entity.HasOne(d => d.Category).WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__InvoiceIt__categ__4D5F7D71");

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__InvoiceIt__invoi__4C6B5938");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3213E83F1153567F");

            entity.ToTable("Location");

            entity.HasIndex(e => e.Name, "UQ__Location__72E12F1B5F46E249").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vendor__3213E83FFA892102");

            entity.ToTable("Vendor");

            entity.HasIndex(e => e.VatNo, "UQ__Vendor__B444FCAA6FAFD8C3").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contact)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("contact");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.VatNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("vat_no");

            entity.HasOne(d => d.Location).WithMany(p => p.Vendors)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Vendor__location__43D61337");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
