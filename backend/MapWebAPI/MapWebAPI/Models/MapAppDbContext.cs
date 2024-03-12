using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MapWebAPI.Models;

public partial class MapAppDbContext : DbContext
{
    public MapAppDbContext()
    {
    }

    public MapAppDbContext(DbContextOptions<MapAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attribute> Attributes { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<LocationType> LocationTypes { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=MapAppDB;User Id=SA;Password=CSharpCool_1!;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attribute>(entity =>
        {
            entity.HasKey(e => e.AttributeId).HasName("PK__Attribut__C18929EABA5C8DE7");

            entity.Property(e => e.AttributeId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.LocationType).WithMany(p => p.Attributes)
                .HasForeignKey(d => d.LocationTypeId)
                .HasConstraintName("FK__Attribute__Locat__29572725");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA497D0DBDC5C");

            entity.Property(e => e.LocationId).ValueGeneratedNever();
            entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.LocationType).WithMany(p => p.Locations)
                .HasForeignKey(d => d.LocationTypeId)
                .HasConstraintName("FK__Locations__Locat__267ABA7A");
        });

        modelBuilder.Entity<LocationType>(entity =>
        {
            entity.HasKey(e => e.LocationTypeId).HasName("PK__Location__737D32F95032DA9A");

            entity.Property(e => e.LocationTypeId).ValueGeneratedNever();
            entity.Property(e => e.IconPath)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TypeName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79CEA081B53A");

            entity.Property(e => e.ReviewId).ValueGeneratedNever();
            entity.Property(e => e.Comment).HasColumnType("text");

            entity.HasOne(d => d.Location).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK__Reviews__Locatio__2C3393D0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
