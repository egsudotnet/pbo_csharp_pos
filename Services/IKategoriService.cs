using POSApplication.Models;

namespace POSApplication.Services
{
    public interface IKategoriService
    {
        Task<IEnumerable<Kategori>> GetAllAsync();
        Task<Kategori> GetByIdAsync(int id);
        Task AddAsync(Kategori Kategori);
        Task UpdateAsync(Kategori Kategori);
        Task DeleteAsync(int id);
    }
}