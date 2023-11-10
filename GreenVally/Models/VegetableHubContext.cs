using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GreenValley.Models;

public partial class VegetableHubContext : DbContext
{
    public VegetableHubContext()
    {
    }

    public VegetableHubContext(DbContextOptions<VegetableHubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomerDetail> CustomerDetails { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<VegetableDetail> VegetableDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-2DK5H2Q\\SQLEXPRESS01;Database=VegetableHub;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerDetail>(entity =>
        {
            entity.HasKey(e => e.CustId).HasName("PK__Customer__7B895117E7B0D7AE");

            entity.ToTable("Customer_Details");

            entity.Property(e => e.CustId).HasColumnName("Cust_Id");
            entity.Property(e => e.UserId).HasColumnName("User_Id");
            entity.Property(e => e.VegId).HasColumnName("Veg_Id");
            entity.Property(e => e.VgPrice).HasColumnName("Vg_price");

            entity.HasOne(d => d.User).WithMany(p => p.CustomerDetails)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Customer___User___60A75C0F");

            entity.HasOne(d => d.Veg).WithMany(p => p.CustomerDetails)
                .HasForeignKey(d => d.VegId)
                .HasConstraintName("FK__Customer___Veg_I__619B8048");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Logins__206A9DF8BFB2D6F3");

            entity.Property(e => e.UserId).HasColumnName("User_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("User_Name");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(250)
                .HasColumnName("User_password");
        });

        modelBuilder.Entity<VegetableDetail>(entity =>
        {
            entity.HasKey(e => e.VegId).HasName("PK__Vegetabl__0AE585809D20D2D3");

            entity.ToTable("Vegetable_Details");

            entity.Property(e => e.VegId).HasColumnName("Veg_Id");
            entity.Property(e => e.VegName)
                .HasMaxLength(100)
                .HasColumnName("Veg_Name");

            entity.HasOne(d => d.User).WithMany(p => p.VegetableDetails)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Vegetable__UserI__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
