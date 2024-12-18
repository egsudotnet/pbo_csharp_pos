using System;
using System.Collections.Generic;

namespace POSApplication.Models;

public partial class Kategori
{
    public int Id { get; set; }

    public string Nama { get; set; } = null!;

    public string? Deskripsi { get; set; }

    public virtual ICollection<Barang> Barangs { get; set; } = new List<Barang>();
}
