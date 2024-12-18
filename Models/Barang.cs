using System;
using System.Collections.Generic;

namespace POSApplication.Models;

public partial class Barang
{
    public int Id { get; set; }

    public string Nama { get; set; } = null!;

    public decimal HargaJual { get; set; }

    public int Stok { get; set; }

    public string Kode { get; set; } = null!;

    public int? KategoriId { get; set; }

    public virtual ICollection<DetailPenjualan> DetailPenjualans { get; set; } = new List<DetailPenjualan>();

    public virtual Kategori? Kategori { get; set; }
}
