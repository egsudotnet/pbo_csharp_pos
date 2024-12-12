using POSApplication.Models;

namespace POSApplication.Services
{
    public interface IBarangService
    {
        Task<IEnumerable<Barang>> GetAllAsync();
        Task<Barang> GetByIdAsync(int id);
        Task AddAsync(Barang barang);
        Task UpdateAsync(Barang barang);
        Task DeleteAsync(int id);
    }
}