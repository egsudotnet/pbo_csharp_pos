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

    public virtual DbSet<Penjualan> Penjualans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost:5432;Database=PBO_POS;Username=postgres;Password=berharap-YOGYA2#");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Barang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("barang_pkey");

            entity.ToTable("Barang");

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('barang_id_seq'::regclass)");
            entity.Property(e => e.HargaJual).HasPrecision(10, 2);
            entity.Property(e => e.Nama).HasMaxLength(100);
        });

        modelBuilder.Entity<DetailPenjualan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("DetailPenjualan_pkey");

            entity.ToTable("DetailPenjualan");

            entity.Property(e => e.Harga).HasPrecision(18, 2);

            entity.HasOne(d => d.Barang).WithMany(p => p.DetailPenjualans)
                .HasForeignKey(d => d.BarangId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DetailPenjualan_BarangId_fkey");

            entity.HasOne(d => d.Penjualan).WithMany(p => p.DetailPenjualans)
                .HasForeignKey(d => d.PenjualanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DetailPenjualan_PenjualanId_fkey");
        });

        modelBuilder.Entity<Penjualan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Penjualan_pkey");

            entity.ToTable("Penjualan");

            entity.Property(e => e.Tanggal).HasColumnType("timestamp without time zone");
            entity.Property(e => e.TotalHarga).HasPrecision(18, 2);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
