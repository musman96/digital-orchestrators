using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FBI.WebAPI.Models;

public partial class FbiContext : DbContext
{
    public FbiContext()
    {
    }

    public FbiContext(DbContextOptions<FbiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CriminalDetail> CriminalDetails { get; set; }

    public virtual DbSet<ListofCrime> ListofCrimes { get; set; }

    public virtual DbSet<NextOfKin> NextOfKins { get; set; }

    public virtual DbSet<Option> Options { get; set; }

    public virtual DbSet<OptionGroup> OptionGroups { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CriminalDetail>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastKnownAddress)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.PrisonName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ListofCrime>(entity =>
        {
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DateCommitted).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Criminal).WithMany(p => p.ListofCrimes)
                .HasForeignKey(d => d.CriminalId)
                .HasConstraintName("FK_ListofCrimes_Criminals");
        });

        modelBuilder.Entity<NextOfKin>(entity =>
        {
            entity.ToTable("NextOfKin");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Relationship).WithMany(p => p.NextOfKins)
                .HasForeignKey(d => d.RelationshipId)
                .HasConstraintName("FK_NextOfKin_Option");
        });

        modelBuilder.Entity<Option>(entity =>
        {
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.OptionGroup).WithMany(p => p.Options)
                .HasForeignKey(d => d.OptionGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Options_OptionGroup");
        });

        modelBuilder.Entity<OptionGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_OptionGrouo");

            entity.ToTable("OptionGroup");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
