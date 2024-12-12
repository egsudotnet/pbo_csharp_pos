using POSApplication.Models;

public interface IPenjualanService
{
    Task<bool> AddPenjualanAsync(Penjualan penjualan, List<DetailPenjualan> detailPenjualans);
}
