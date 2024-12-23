using System;
using System.Collections.Generic;

namespace POSApplication.ViewModels;

public partial class BarangViewModel
{
    public int Id { get; set; }

    public string Nama { get; set; } = null!;

    public decimal HargaJual { get; set; }

    public int Stok { get; set; }

    public string Kode { get; set; } = null!;

    public int? KategoriId { get; set; }

 
    public string? Kategori { get; set; }
}


