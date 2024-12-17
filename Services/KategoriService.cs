using Microsoft.EntityFrameworkCore;
using POSApplication.Models;

namespace POSApplication.Services
{
    public class KategoriService : IKategoriService
    {
        private readonly PboPosContext _context;

        public KategoriService(PboPosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Kategori>> GetAllAsync()
        {
            return await _context.Kategoris.ToListAsync();
        }

        public async Task<Kategori> GetByIdAsync(int id)
        {
            return await _context.Kategoris.FindAsync(id);
        }

        public async Task AddAsync(Kategori Kategori)
        {
            _context.Kategoris.Add(Kategori);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Kategori Kategori)
        {
            _context.Kategoris.Update(Kategori);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Kategori = await _context.Kategoris.FindAsync(id);
            if (Kategori != null)
            {
                _context.Kategoris.Remove(Kategori);
                await _context.SaveChangesAsync();
            }
        }
    }
}
