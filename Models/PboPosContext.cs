using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace POSApplication.Models;

public partial class PboPosContext : DbContext
{
    public PboPosContext()
    {
    }

    public PboPosContext(DbContextOptions<PboPosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Barang> Barangs { get; set; }

    public virtual DbSet<DetailPenjualan> DetailPenjualans { get; set; }

    public virtual DbSet<Kategori> Kategoris { get; set; }

    public virtual DbSet<Penjualan> Penjualans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Barang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("barang_pkey");

            entity.ToTable("barang");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HargaJual)
                .HasPrecision(10, 2)
                .HasColumnName("hargaJual");
            entity.Property(e => e.KategoriId).HasColumnName("kategoriId");
            entity.Property(e => e.Kode)
                .HasColumnType("character varying")
                .HasColumnName("kode");
            entity.Property(e => e.Nama)
                .HasMaxLength(100)
                .HasColumnName("nama");
            entity.Property(e => e.Stok).HasColumnName("stok");

            entity.HasOne(d => d.Kategori).WithMany(p => p.Barangs)
                .HasForeignKey(d => d.KategoriId)
                .HasConstraintName("kategori_fk");
        });

        modelBuilder.Entity<DetailPenjualan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("detailPenjualan_pkey");

            entity.ToTable("detailPenjualan");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BarangId).HasColumnName("barangId");
            entity.Property(e => e.Harga)
                .HasPrecision(18, 2)
                .HasColumnName("harga");
            entity.Property(e => e.Jumlah).HasColumnName("jumlah");
            entity.Property(e => e.PenjualanId).HasColumnName("penjualanId");

            entity.HasOne(d => d.Barang).WithMany(p => p.DetailPenjualans)
                .HasForeignKey(d => d.BarangId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detailPenjualan_barangId_fkey");

            entity.HasOne(d => d.Penjualan).WithMany(p => p.DetailPenjualans)
                .HasForeignKey(d => d.PenjualanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detailPenjualan_penjualanId_fkey");
        });

        modelBuilder.Entity<Kategori>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("kategori_pkey");

            entity.ToTable("kategori");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Deskripsi).HasColumnName("deskripsi");
            entity.Property(e => e.Nama)
                .HasMaxLength(100)
                .HasColumnName("nama");
        });

        modelBuilder.Entity<Penjualan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("penjualan_pkey");

            entity.ToTable("penjualan");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tanggal)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("tanggal");
            entity.Property(e => e.TotalHarga)
                .HasPrecision(18, 2)
                .HasColumnName("totalHarga");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
