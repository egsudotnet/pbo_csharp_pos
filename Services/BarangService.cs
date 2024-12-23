using Microsoft.EntityFrameworkCore;
using POSApplication.Models;
using POSApplication.ViewModels;


namespace POSApplication.Services
{
    public class BarangService : IBarangService
    {
        private readonly PboPosContext _context;

        public BarangService(PboPosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BarangViewModel>> GetAllAsync()
        {
            var barangList = await _context.Barangs
                .Include(b => b.Kategori) // Eager Loading relasi Kategori
                .ToListAsync();

            // Map ke BarangViewModel
            var result = barangList.Select(b => new BarangViewModel
            { 
                Id = b.Id,
                Nama = b.Nama,
                HargaJual = b.HargaJual,
                Stok = b.Stok,
                Kode = b.Kode,
                KategoriId = b.KategoriId,
                Kategori = b.Kategori?.Nama // Ambil nama kategori
            });

            return result;
        }


        public async Task<BarangViewModel> GetByIdAsync(int id)
        {
            var barang = await _context.Barangs
                .Include(b => b.Kategori)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (barang == null) return null;

            return new BarangViewModel
            {
                Id = barang.Id,
                Nama = barang.Nama,
                HargaJual = barang.HargaJual,
                Stok = barang.Stok,
                Kode = barang.Kode,
                KategoriId = barang.KategoriId,
                Kategori = barang.Kategori?.Nama
            };
        }


        public async Task AddAsync(Barang barang)
        {
            _context.Barangs.Add(barang);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Barang barang)
        {
            _context.Barangs.Update(barang);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var barang = await _context.Barangs.FindAsync(id);
            if (barang != null)
            {
                _context.Barangs.Remove(barang);
                await _context.SaveChangesAsync();
            }
        }
    }
}
