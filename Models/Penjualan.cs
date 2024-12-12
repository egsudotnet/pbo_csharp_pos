using System;
using System.Collections.Generic;

namespace POSApplication.Models;

public partial class Penjualan
{
    public int Id { get; set; }

    public DateTime Tanggal { get; set; }

    public decimal TotalHarga { get; set; }

    public virtual ICollection<DetailPenjualan> DetailPenjualans { get; set; } = new List<DetailPenjualan>();
}
