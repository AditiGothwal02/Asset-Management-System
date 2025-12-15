using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementWebApi.Models;

public partial class AssetManagementContext : DbContext
{
    public AssetManagementContext()
    {
    }

    public AssetManagementContext(DbContextOptions<AssetManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Hardware> Hardwares { get; set; }

    public virtual DbSet<Software> Softwares { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC07CEF19DBE");

            entity.Property(e => e.Name).HasMaxLength(256);

            entity.HasOne(d => d.AssignedUser).WithMany(p => p.Books)
                .HasForeignKey(d => d.AssignedUserId)
                .HasConstraintName("FK_Books_Users");
        });

        modelBuilder.Entity<Hardware>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hardware__3214EC0775915852");

            entity.ToTable("Hardware");

            entity.Property(e => e.Name).HasMaxLength(256);

            entity.HasOne(d => d.AssignedUser).WithMany(p => p.Hardwares)
                .HasForeignKey(d => d.AssignedUserId)
                .HasConstraintName("FK_Hardware_Users");
        });

        modelBuilder.Entity<Software>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Software__3214EC07B81802F4");

            entity.ToTable("Software");

            entity.Property(e => e.LicenseKey).HasMaxLength(256);
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.Version).HasMaxLength(256);

            entity.HasOne(d => d.AssignedUser).WithMany(p => p.Softwares)
                .HasForeignKey(d => d.AssignedUserId)
                .HasConstraintName("FK_Software_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07E406F5A7");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105341A14480F").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.PasswordHash).HasMaxLength(200);
            entity.Property(e => e.Username).HasMaxLength(256);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
