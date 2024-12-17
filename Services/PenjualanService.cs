// using Microsoft.EntityFrameworkCore;
// using POSApplication.Models;
// using POSApplication.Services;

// namespace POSApplication.Services
// {
//   public class PenjualanService : IPenjualanService
// {
//     private readonly PboPosContext _context;

//     public PenjualanService(PboPosContext context)
//     {
//         _context = context;
//     }

//     public async Task<bool> AddPenjualanAsync(Penjualan penjualan, List<DetailPenjualan> detailPenjualans)
//     {
//         using var transaction = await _context.Database.BeginTransactionAsync();
//         try
//         {
//             // Tambahkan transaksi penjualan
//             _context.Penjualans.Add(penjualan);
//             await _context.SaveChangesAsync();

//             // Tambahkan detail penjualan
//             foreach (var detail in detailPenjualans)
//             {
//                 detail.PenjualanId = penjualan.Id;
//                 _context.DetailPenjualans.Add(detail);
//             }

//             await _context.SaveChangesAsync();

//             // Commit transaksi
//             await transaction.CommitAsync();
//             return true;
//         }
//         catch
//         {
//             await transaction.RollbackAsync();
//             return false;
//         }
//     }
// }

// }
