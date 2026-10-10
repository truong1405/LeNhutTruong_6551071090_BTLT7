using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TriThucBooks.Models;

public partial class TriThucBooksContext : DbContext
{
    public TriThucBooksContext()
    {
    }

    public TriThucBooksContext(DbContextOptions<TriThucBooksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TheLoaiSach> TheLoaiSaches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=TriThucBooks;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TheLoaiSach>(entity =>
        {
            entity.HasKey(e => e.MaTl).HasName("PK__TheLoaiS__272500712118D106");

            entity.ToTable("TheLoaiSach");

            entity.HasIndex(e => e.TenTheLoai, "UQ__TheLoaiS__327F958FE20A6114").IsUnique();

            entity.Property(e => e.MaTl).HasColumnName("MaTL");
            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TenTheLoai).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
