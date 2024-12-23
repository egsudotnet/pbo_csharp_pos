using POSApplication.Models;
using POSApplication.ViewModels;


namespace POSApplication.Services
{
    public interface IBarangService
    {
        Task<IEnumerable<BarangViewModel>> GetAllAsync();
        Task<Barang> GetByIdAsync(int id);
        Task AddAsync(Barang barang);
        Task UpdateAsync(Barang barang);
        Task DeleteAsync(int id);
    }
}