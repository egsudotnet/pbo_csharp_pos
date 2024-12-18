using Microsoft.EntityFrameworkCore;
using POSApplication.Models;

namespace POSApplication.Services
{
    public class BarangService : IBarangService
    {
        private readonly PboPosContext _context;

        public BarangService(PboPosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Barang>> GetAllAsync()
        {
            var barangList = await _context.Barangs
                .Include(b => b.Kategori) // Eager Loading relasi Kategori
                .ToListAsync();
            return barangList;
        }

        public async Task<Barang> GetByIdAsync(int id)
        {
            return await _context.Barangs.FindAsync(id);
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
