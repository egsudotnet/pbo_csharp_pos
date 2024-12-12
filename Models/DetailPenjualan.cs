using System;
using System.Collections.Generic;

namespace POSApplication.Models;

public partial class DetailPenjualan
{
    public int Id { get; set; }

    public int PenjualanId { get; set; }

    public int BarangId { get; set; }

    public int Jumlah { get; set; }

    public decimal Harga { get; set; }

    public virtual Barang Barang { get; set; } = null!;

    public virtual Penjualan Penjualan { get; set; } = null!;
}
