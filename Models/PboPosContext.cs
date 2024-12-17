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

    public virtual DbSet<Kategori> Kategoris { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=141.11.160.30:5432;Database=PBO_POS;Username=postgres;Password=berharap-YOGYA2#");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Barang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("barang_pkey");

            entity.ToTable("Barang");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('barang_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.HargaJual)
                .HasPrecision(10, 2)
                .HasColumnName("hargaJual");
            entity.Property(e => e.Nama)
                .HasMaxLength(100)
                .HasColumnName("nama");
            entity.Property(e => e.Stok).HasColumnName("stok");
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
